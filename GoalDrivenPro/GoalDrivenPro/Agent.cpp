#include "Goal_Think.h"
#include "Agent.h"



Agent::Agent(int id) :
	ID (id)
{
	Brain = new Goal_Think(this);

}

void Agent::tapCodes(int num)
{
	CurCodeLine += num;
}

void Agent::produceArtRes(int num)
{
	CurArtistResSize += num;
}
