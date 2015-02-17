FROM rmacdonaldsmith/docker-debian-mono-devel
RUN apt-get update
RUN apt-get install -y curl
WORKDIR /tmp
ENV EnableNuGetPackageRestore true
ADD . /app
WORKDIR /app
RUN nuget restore SimpleNancy.sln -Source https://www.nuget.org/api/v2/
RUN xbuild SimpleNancy.sln
EXPOSE 1234
#ENTRYPOINT  ["mono", "SimpleNancy.SelfHost/bin/Debug/SimpleNancy.SelfHost.exe"]
#CMD ["/usr/bin/mono", "SimpleNancy.SelfHost/bin/Debug/SimpleNancy.SelfHost.exe"] 
RUN chmod +x run.sh
CMD ./run.sh
