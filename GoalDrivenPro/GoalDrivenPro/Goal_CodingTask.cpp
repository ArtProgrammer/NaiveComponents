#include <windows.h>
#include <iostream>
#include <sstream>
#include "Goal_CodingTask.h"



Goal_CodingTask::Goal_CodingTask(Agent* agent) :
	Goal<Agent>(agent, goal_codingtask),
	Line(0)
{

}

void Goal_CodingTask::activate()
{
	m_Status = active;
}

int Goal_CodingTask::process()
{
	activateIfInactive();

	std::stringstream ss;
	ss << m_Owner->getCurCodeLine();

	std::cout << "Farmer coding..." << ss.str() << std::endl;

	m_Owner->tapCodes(1);

	Sleep(1000);

	if (m_Owner->isCodeAllFinished())
	{
		m_Status = completed;
	}

	return m_Status;
}

void Goal_CodingTask::terminate()
{

}