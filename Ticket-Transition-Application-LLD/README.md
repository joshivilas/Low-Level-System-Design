Ticket Transitioning Application :

        e.g. JIRA ticketing system

Requirements: 
    - user can create a ticket
    - user can update the state of ticket



Classes:


class User:
    string name;


enum TicketState:


class Ticket:
    string description;
    TicketState ticketState;
    User createdBy;

class TicketService:
    Ticket createTicket(string description, User createdBy);
    void changesTicketState(Ticket ticket, TicketState newState);


