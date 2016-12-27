﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FXStudio
{
    class XmlUtility
    {
        static int GetNodePosition(XmlNode child)
        {
            int count = 1;
            for (int i = 0; i < child.ParentNode.ChildNodes.Count; i++)
            {
                if (child.ParentNode.ChildNodes[i] == child)
                {
                    return count;
                }
                if (child.ParentNode.ChildNodes[i].Name == child.Name)
                {
                    ++count;
                }
            }
            throw new InvalidOperationException("Child node somehow not found in its parent's ChildNodes property.");
        }

        public static string GetXPathToNode(XmlNode node)
        {
            if (node.NodeType == XmlNodeType.Attribute)
            {
                return String.Format(
                    "{0}/@{1}",
                    GetXPathToNode(((XmlAttribute)node).OwnerElement),
                    "*"
                    );
            }

            if (node.ParentNode == null)
            {
                return "";
            }
            return String.Format(
                "{0}/{1}[{2}]",
                GetXPathToNode(node.ParentNode),
                "*",
                GetNodePosition(node)
                );
        }

        public static XmlAttribute CreateAttribute(XmlDocument xmlDoc, string name, string value)
        {
            XmlAttribute attribute = xmlDoc.CreateAttribute(name);
            attribute.Value = value;
            return attribute;
        }

        public static XmlElement CreateTransformComponent(XmlDocument xmlDoc, string tx = "0", string ty = "0", string tz = "0")
        {
            XmlElement transformElement = xmlDoc.CreateElement("TransformComponent");

            XmlElement translation = xmlDoc.CreateElement("Translation");
            XmlElement scale = xmlDoc.CreateElement("Scale");
            XmlElement rotation = xmlDoc.CreateElement("Rotation");
            transformElement.AppendChild(translation);
            transformElement.AppendChild(scale);
            transformElement.AppendChild(rotation);

            translation.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "x", tx));
            translation.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "y", ty));
            translation.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "z", tz));

            scale.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "x", "1"));
            scale.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "y", "1"));
            scale.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "z", "1"));

            rotation.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "x", "0"));
            rotation.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "y", "0"));
            rotation.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "z", "0"));

            return transformElement;
        }

        static XmlElement CreateColorElement(XmlDocument xmlDoc)
        {
            XmlElement color = xmlDoc.CreateElement("Color");
            color.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "r", "1"));
            color.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "g", "1"));
            color.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "b", "1"));
            color.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "a", "1"));

            return color;
        }

        public static XmlElement CreateCubeRenderComponent(XmlDocument xmlDoc)
        {
            XmlElement sphereElement = xmlDoc.CreateElement("CubeRenderComponent");
            sphereElement.AppendChild(CreateColorElement(xmlDoc));

            XmlElement texture = xmlDoc.CreateElement("Texture");
            XmlElement effect = xmlDoc.CreateElement("Effect");
            XmlElement cube = xmlDoc.CreateElement("Cube");
            sphereElement.AppendChild(texture);
            sphereElement.AppendChild(effect);
            sphereElement.AppendChild(cube);


            texture.InnerText = @"Textures\DefaultTexture.dds";

            effect.InnerText = @"Effects\DefaultEffect.fx";
            effect.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "technique", "main11"));
            effect.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "pass", "p0"));

            cube.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "size", "1.0"));
            cube.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "rhcoords", "1"));
            
            return sphereElement;
        }

        public static XmlElement CreateSphereRenderComponent(XmlDocument xmlDoc)
        {
            XmlElement sphereElement = xmlDoc.CreateElement("SphereRenderComponent");
            sphereElement.AppendChild(CreateColorElement(xmlDoc));

            XmlElement texture = xmlDoc.CreateElement("Texture");
            XmlElement effect = xmlDoc.CreateElement("Effect");
            XmlElement sphere = xmlDoc.CreateElement("Sphere");
            sphereElement.AppendChild(texture);
            sphereElement.AppendChild(effect);
            sphereElement.AppendChild(sphere);


            texture.InnerText = @"Textures\DefaultTexture.dds";

            effect.InnerText = @"Effects\DefaultEffect.fx";
            effect.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "technique", "main11"));
            effect.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "pass", "p0"));

            sphere.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "diameter", "1.0"));
            sphere.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "tessellation", "3"));
            sphere.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "rhcoords", "1"));
            
            return sphereElement;
        }

        public static XmlElement CreateCylinderRenderComponent(XmlDocument xmlDoc)
        {
            XmlElement sphereElement = xmlDoc.CreateElement("CylinderRenderComponent");
            sphereElement.AppendChild(CreateColorElement(xmlDoc));

            XmlElement texture = xmlDoc.CreateElement("Texture");
            XmlElement effect = xmlDoc.CreateElement("Effect");
            XmlElement cylinder = xmlDoc.CreateElement("Cylinder");
            sphereElement.AppendChild(texture);
            sphereElement.AppendChild(effect);
            sphereElement.AppendChild(cylinder);


            texture.InnerText = @"Textures\DefaultTexture.dds";

            effect.InnerText = @"Effects\DefaultEffect.fx";
            effect.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "technique", "main11"));
            effect.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "pass", "p0"));

            cylinder.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "height", "1.0"));
            cylinder.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "diameter", "1.0"));
            cylinder.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "tessellation", "32"));
            cylinder.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "rhcoords", "1"));
            
            return sphereElement;
        }

        public static XmlElement CreateTeapotRenderComponent(XmlDocument xmlDoc)
        {
            XmlElement sphereElement = xmlDoc.CreateElement("TeapotRenderComponent");
            sphereElement.AppendChild(CreateColorElement(xmlDoc));

            XmlElement texture = xmlDoc.CreateElement("Texture");
            XmlElement effect = xmlDoc.CreateElement("Effect");
            XmlElement teapot = xmlDoc.CreateElement("Teapot");
            sphereElement.AppendChild(texture);
            sphereElement.AppendChild(effect);
            sphereElement.AppendChild(teapot);


            texture.InnerText = @"Textures\DefaultTexture.dds";

            effect.InnerText = @"Effects\DefaultEffect.fx";
            effect.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "technique", "main11"));
            effect.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "pass", "p0"));

            teapot.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "size", "1.0"));
            teapot.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "tessellation", "8"));
            teapot.Attributes.Append(XmlUtility.CreateAttribute(xmlDoc, "rhcoords", "1"));
            
            return sphereElement;
        }
    }
}