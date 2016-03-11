#include <windows.h>
#include <iostream>
#include <sstream>
#include "Goal_ArtistResTask.h"



Goal_ArtistResTask::Goal_ArtistResTask(Agent* agent) :
	Goal<Agent>(agent, goal_artistrestask)
{

}

void Goal_ArtistResTask::activate()
{
	m_Status = active;
}

int Goal_ArtistResTask::process()
{
	activateIfInactive();

	m_Owner->produceArtRes(1);

	std::stringstream ss;
	ss << m_Owner->getCurArtistResSize();

	std::cout << "Art dog produce..." << ss.str() << std::endl;

	Sleep(1000);

	if (m_Owner->isArtistResWorkOk())
	{
		m_Status = completed;
	}

	return m_Status;
}

void Goal_ArtistResTask::terminate()
{

}
