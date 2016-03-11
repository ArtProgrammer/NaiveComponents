#include <iostream>
#include "Goal_Think.h"
#include <string>

extern "C"
{
#include "lua.h"
#include "lauxlib.h"
#include "lualib.h"
}


using namespace std;



int main()
{
	lua_State* L = luaL_newstate();

	luaL_openlibs(L);

	luaL_dostring(L, "print(\"hello\")");

	luaL_dofile(L, "mini.lua");

	//luaL_dostring(L, "for fname in dir.open(\".\") do print(fname) end");

	cout << "brain begin:\n";

	Agent* codeFarmer = new Agent(0);

	codeFarmer->setTotalCodeLine(30);
	codeFarmer->setTotalArtResSize(16);

	while (true)
	{
		codeFarmer->getBrain()->process();
	}

	cout << "$$$ : Goal driven behavior end!" << endl;

	return 0;
}
