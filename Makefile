make:
	@xbuild /p:Configuration=Release GlfwSharp.csproj
	@cp -r Data bin/Release/

clean:
	@rm -rf bin/Release/*
