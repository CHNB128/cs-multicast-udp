build=./build
src=./src

all:
	mcs -o ${build}/Server ${src}/Server.cs
	mcs -o ${build}/Client ${src}/Client.cs
	chmod +x ${build}/Server.cs ${build}/Client.cs