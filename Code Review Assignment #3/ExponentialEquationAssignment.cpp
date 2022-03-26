#include<iostream>
#include<sstream>

using namespace std;

class Term {
private:

	int coefficient; //It will represent the coefficient of the polynomial :
	int exponent;	 //It will represent the exponent of the polynomial :
	Term* next;      //Pointer to point on the next node :   

public:


	//constructor :
	Term(int coef, int exp) {

		set_exponent(exp);
		set_coefficient(coef);
		next = NULL;
	}

	//seter :
	void set_coefficient(int coef) {
		coefficient = coef;
	}

	void set_exponent(int exp) {

		exponent = exp;
	}

	Term* set_next(Term* n) {
		next = n;
		return next;
	}
	//geter :
	int get_coefficient() {
		return coefficient;
	}

	int get_exponent() {
		return exponent;
	}

	Term* get_next() {
		return next;
	}


};

class polynomial {
private:

	Term* first;

public:

	//constructor :
	polynomial() {
		first = NULL;
	}

	//method's :
	Term* create_poly(Term* new_node);
	void display_poly(Term* f);
	Term* delete_term(int exp, int coff);
	Term* derivative(Term* f);
	void reverse(Term* f);
	Term* get_first();
	Term* create_node(int coff, int exp);
	string to_string(Term* f);

};

//Function for geter function for first :
Term* polynomial::get_first() {
	return first;
}

//Function for create node :
Term* polynomial::create_node(int coff, int exp) {
	Term* new_node;
	new_node = new Term(coff, exp);
	return new_node;
}

//Function for create polynomial :
Term* polynomial::create_poly(Term* new_node, Term* p, Term* p2 , Term* firstnode) {

 
	p = p2 = firstnode= first;

 

	else if (new_node->get_exponent() > firstnode->get_exponent()) {
		new_node->set_next(first);
        firstnode = new_node;

	}
	else {
		p = p2 = firstnode;
		while (p2 != NULL) {
			if (new_node->get_exponent() > p2->get_exponent()) {
				new_node->set_next(p2);
				p->set_next(new_node);
				break;
			}
			else

				p = p2;
			p2 = p2->get_next();
		}

		if (p2 == NULL)
			p->set_next(new_node);

	}

	return firstnode;
}

//Function for print the polynomial :
void polynomial::display_poly(Term* f) {

	Term* curr, * p;

	curr = p = f;
	while (curr != NULL) {
		p = p->get_next();

		cout << "--->" << "coefficient = " << curr->get_coefficient() << " , " << " exponent = " << curr->get_exponent();
		if (p == NULL)
			cout << "---> NULL";

		curr = curr->get_next();
	}
}

string polynomial::to_string(Term* f) {

	stringstream ss;
	Term* curr, * p;

	curr = p = f;
	while (curr != NULL) {
		p = p->get_next();

		ss << curr->get_coefficient() << "x^" << curr->get_exponent();
		if (p != NULL)
			ss << " + ";
		curr = curr->get_next();
	}
	string new_sring = ss.str();
	return new_sring;
}

//Function for delete term from polynomial :
Term* polynomial::delete_term(int exp, int coff) {

	if (first == NULL) {
		cout << "\n\n list is empty " << endl;
		return first;
	}



	Term* p, * curr = first;

	p = first->get_next();

	if (first->get_coefficient() == coff && first->get_exponent() == exp) {
		first = first->get_next();
		delete curr;
		return first;
	}


	while (p != NULL) {
		if (p->get_coefficient() == coff && p->get_exponent() == exp) {
			curr->set_next(p->get_next());
			delete p;
			return first;
		}

		else
		{
			curr = p;
			p = p->get_next();
		}

	}

	return first;

}


//Function to  find the first and second derivative polynomial : 
Term* polynomial::derivative(Term* p) {



	polynomial t;
	int exp, coff;
	Term* H = NULL;
	Term* d;
	d = NULL;

	while (p != NULL) {

		coff = p->get_coefficient() * p->get_exponent();
		exp = p->get_exponent() - 1;
		H = t.create_node(coff, exp);
		d = t.create_poly(H);
		p = p->get_next();

	}

	return d;
}

//Function to  Reverse the order of the terms of the polynomial : 
void polynomial::reverse(Term* f) {

	if (f == NULL)
	{
		return;
	}

	reverse(f->get_next());


	cout << f->get_coefficient() << "x^" << f->get_exponent();
	if (f != first)
		cout << " + ";

}

//->>>>>>>>>>
class Test {

private:

	polynomial test;
	polynomial t;


public:

	void menu();
	void emplementation();

};


void Test::menu() {

	cout << '\t' << '\t' << "****************************************MENU*****************************************  " << endl;
	cout << '\t' << '\t' << "* Enter 1 to creat polynomial                                                       *  " << endl;
	cout << '\t' << '\t' << "* Enter 2 to Remove the term with coefficient X and exponent Y from the polynomial  *  " << endl;
	cout << '\t' << '\t' << "* Enter 3 to Reverse the order of the terms of the polynomial                       *  " << endl;
	cout << '\t' << '\t' << "* Enter 4 to to find the first derivatives of the polynomial                        *  " << endl;
	cout << '\t' << '\t' << "* Enter 5 to to find the second derivatives of the polynomial                       *  " << endl;
	cout << '\t' << '\t' << "* Enter 6 to exit                                                                   *  " << endl;
	cout << '\t' << '\t' << "*************************************************************************************  " << endl;

}

void Test::emplementation() {

	int choice, e = 0, exp, coff;
	string s;


	menu();

	Term* d = NULL;
	Term* g = NULL;
	Term* g2 = NULL;

    Term* p = NULL, p2 = NULL, firstnode = NULL;
	cout << "\n\n Enter your choice from the menue : ";
	cin >> choice;

	while (choice < 1 || choice>6) {
		cout << "wrong choice , pleaze enter it again :";
		cin >> choice;
	}

	do {

		if (choice == 6) {
			cout << "\n\t\t Thank's you for using my proggram :) \n";
			break;
		}

		switch (choice)
		{

		case 1:
		{
			cout << "\n enter the exponent : ";
			cin >> exp;
			while (exp < 0) {
				cout << "wrong input, plz enter a new one :";
				cin >> exp;
			}
			cout << "\n Enter the coefficient : ";
			cin >> coff;


			Term* new_node = NULL;
			new_node = test.create_node(coff, exp);

			d = test.create_poly(new_node);

			cout << "Link List is : \n" << endl;
			s = test.to_string(d);
			cout << s;
			cout << endl << endl;

			cout << "echo printed : \n" << endl;
			test.display_poly(d);
			cout << endl;
			cout << "...............................................................................................................";
			cout << endl << endl;

			break;
		}

		case 2:
		{

			cout << "\n enter the exponent : ";
			cin >> exp;

			cout << "\n Enter the coefficient : ";
			cin >> coff;


			Term* chick = test.get_first();
			bool ch = 0;

			while (chick != NULL) {
				if ((chick->get_coefficient() == coff) && (chick->get_exponent() == exp)) {
					ch = 0;
					break;
				}
				else {
					ch = 1;
					chick = chick->get_next();
				}

			}

			while (ch == 1) {
				cout << "\n\tEroor choice : \n ";
				cout << "\n enter the exponent : ";
				cin >> exp;

				cout << "\n Enter the coefficient : ";
				cin >> coff;

				chick = test.get_first();
				ch = 0;

				while (chick != NULL) {
					if ((chick->get_coefficient() == coff) && (chick->get_exponent() == exp)) {
						ch = 0;
						break;
					}
					else {
						ch = 1;

						chick = chick->get_next();
					}
				}
			}

			d = test.delete_term(exp, coff);

			cout << "Link List is : \n" << endl;
			s = test.to_string(d);
			cout << s;
			cout << endl << endl;

			cout << "echo printed: \n" << endl;
			test.display_poly(d);
			cout << endl;
			cout << "...............................................................................................................";
			cout << endl << endl;
			break;

		}

		case 3:
		{
			test.reverse(test.get_first());


			cout << "Link List is : \n" << endl;
			s = test.to_string(d);
			cout << s;
			cout << endl << endl;

			cout << "echo printed : \n" << endl;
			test.display_poly(d);
			cout << endl;
			cout << "...............................................................................................................";
			cout << endl << endl;
			break;
		}

		case 4:
		{
            
			g = t.derivative(d,p,p2, firstnode);
			cout << "Link List is : \n" << endl;
			s = test.to_string(g);
			cout << s;
			cout << endl << endl;

			cout << "echo printed : \n" << endl;
			test.display_poly(g);
			cout << endl;
			cout << "...............................................................................................................";
			cout << endl << endl;
			e = 1;
			break;
		}

		case 5:
		{
			if (test.get_first() == NULL)
			{
				cout << "\n\n list is empty " << endl;
				cout << endl;
				cout << "...............................................................................................................";
				cout << endl << endl;
				break;
			}
			g2 = test.derivative(d, p, p2, firstnode);
			g2 = test.derivative(g2, p, p2, firstnode);

			cout << "Link List is : \n" << endl;
			s = test.to_string(g2);
			cout << s;
			cout << endl << endl;

			cout << "echo printed : \n" << endl;
			test.display_poly(g2);
			cout << endl;
			cout << "...............................................................................................................";
			cout << endl << endl;
			break;
		}

		}

		menu();

		cout << "\n\n Enter your choice from the menue ";
		cin >> choice;

		while (choice < 1 || choice>6) {
			cout << "wrong choice , pleaze enter it again :";
			cin >> choice;
		}

		if (choice == 6) {
			cout << "\n\t\t Thank's you for using my proggram :) \n";
			break;
		}


	} while (choice != 6);

}


int main() {

	Test f;

	f.emplementation();
}
