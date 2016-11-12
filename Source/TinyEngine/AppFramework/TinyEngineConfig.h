#pragma once
#include "../TinyEngineBase.h"

class TinyEngineConfig
{
public:
	TinyEngineConfig();
	~TinyEngineConfig();

	void InitConfig(const std::string& xmlFilePath, LPWSTR lpCmdLine);

	std::string m_Project;

	std::string m_Renderer;
	uint32_t m_ScreenWidth;
	uint32_t m_ScreenHeight;
	bool m_IsFullScreen;
	bool m_IsVSync;
	uint32_t m_AntiAliasing;

	bool m_IsZipResource;

	unique_ptr<TiXmlDocument> m_pDocument;
};

