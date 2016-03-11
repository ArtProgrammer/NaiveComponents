#include <iostream>
#include "Goal_DevGame.h"
#include "Goal_CodingTask.h"
#include "Goal_ArtistResTask.h"



using namespace std;

void Goal_DevGame::activate()
{
	m_Status = active;

	removeAllSubgoals();

	// if all components of a game have been developed,
	// developing process is completed and start to sell.

	if (m_Owner->isCodeAllFinished())
	{
		//if (!m_Owner->isArtistResWorkOk())
		//{

		//}
		//else
		//{
		//	m_Status = completed;
		//}
		if (m_Owner->isArtistResWorkOk())
		{
			m_Owner->setTotalCodeLine(30);
			m_Owner->setCurCodeLine(0);
			addSubgoal(new Goal_CodingTask(m_Owner));
		}
		else
		{
			m_Owner->setTotalArtResSize(16);
			m_Owner->setCurArtistResSize(0);
			addSubgoal(new Goal_ArtistResTask(m_Owner));
		}
	}
	else
	{
		m_Owner->setTotalCodeLine(30);
		m_Owner->setCurCodeLine(0);
		addSubgoal(new Goal_CodingTask(m_Owner));
	}

	cout << "$ deving game!!!\n start";
}

int Goal_DevGame::process()
{
	activateIfInactive();

	m_Status = (GoalState)processSubgoals();

	return m_Status;
}

bool Goal_DevGame::handleMessage(const Telegram& msg)
{
	bool handled = forwardMessageToFronMostSubgoal(msg);

	if (!handled)
	{
		switch (msg.Msg)
		{
		default:
			break;
		}
	}

	return handled;
}