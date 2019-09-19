using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace UrlsToXml
{
    public class UrlStringsToXml
    {
        private readonly string[] _urls;
        private readonly Logs _logger;
        private XDocument _xDocument;

        public UrlStringsToXml(string filePath, Logs logger)
        {
            _logger = logger == null ? new Logs() : logger;

            try
            {
                _urls = File.ReadAllLines(filePath, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                logger.Error($"Impossible to read {filePath}");
                throw;
            }
            _xDocument = new XDocument();
        }

        public UrlStringsToXml(string[] urls, Logs logger)
        {
            _logger = logger == null ? new Logs() : logger;

            _urls = urls;
            _xDocument = new XDocument();
        }

        public XDocument UrlsToXml()
        {
            XElement xUrls = new XElement("urls");
            foreach (string url in _urls)
            {
                try
                {
                    XElement xHost = null;
                    XElement xSegments = null;
                    XElement xParameters = null;

                    UrlPartsGetter urlPartsGetter = new UrlPartsGetter(url);
                    XElement xUrl = new XElement("urls");

                    xHost = SaveHostToXml(urlPartsGetter);
                    xSegments = SaveSegmentsToXml(urlPartsGetter);
                    xParameters = SaveParametersToXml(urlPartsGetter);

                    if (xHost != null)
                    {
                        xUrl.Add(xHost);
                    }

                    if (xSegments != null)
                    {
                        xUrl.Add(xSegments);
                    }

                    if (xParameters != null)
                    {
                        xUrl.Add(xParameters);
                    }

                    xUrls.Add(xUrl);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    _logger.Error($"Impossible to add {url}");
                }
            }

            _xDocument.Add(xUrls);
            return _xDocument;
        }

        public void SaveUrlsToXml(string filePath)
        {
            try
            {
                _xDocument.Save(filePath);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }

        private XElement SaveHostToXml(UrlPartsGetter urlPartsGetter)
        {
            XElement xHost = new XElement("host");

            XAttribute xHostNameAttribute = new XAttribute("name", urlPartsGetter.GetHost());
            xHost.Add(xHostNameAttribute);

            return xHost;
        }

        private XElement SaveSegmentsToXml(UrlPartsGetter urlPartsGetter)
        {
            XElement xSegments = null;

            var segments = urlPartsGetter.GetUriParts();

            if (segments.Any())
            {
                xSegments = new XElement("uri");

                foreach (var segment in urlPartsGetter.GetUriParts())
                {
                    XElement xSegment = new XElement("segment", segment);
                    xSegments.Add(xSegment);
                }
            }

            return xSegments;
        }

        private XElement SaveParametersToXml(UrlPartsGetter urlPartsGetter)
        {
            XElement xParameters = null;

            var parameters = urlPartsGetter.GetParameters();

            if (parameters.Any())
            {
                xParameters = new XElement("parameters");

                foreach (var kvp in parameters)
                {
                    XElement xParameter = new XElement("parameter");
                    XAttribute xParameterValueAttribute = new XAttribute("value", kvp.Value);
                    XAttribute xParameterKeyAttribute = new XAttribute("key", kvp.Key);

                    xParameter.Add(xParameterValueAttribute, xParameterKeyAttribute);
                    xParameters.Add(xParameter);
                }
            }

            return xParameters;
        }
    }
}
