#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

struct d {
	int a;
	int b;
	int c;
};


void moveWater(int& a, int& b, int cmp) {
	if (a + b > cmp) {
		a = a + b - cmp;
		b = cmp;
	}
	else {
		b = a + b;
		a = 0;
	}
}

int main() {
	int a, b, c;
	cin >> a >> b >> c;
	int visited[201][201][201] = { 0 };
	int idx = 0;
	vector<d> q;
	vector<int> ans;
	d temp;
	temp.a = 0;
	temp.b = 0;
	temp.c = c;
	visited[temp.a][temp.b][temp.c] = 1;
	ans.push_back(temp.c);
	q.push_back(temp);
	while (q.size() > idx) {
		temp = q[idx];
		// a > b
		d temp1 = temp;
		moveWater(temp1.a, temp1.b, b);
		if (visited[temp1.a][temp1.b][temp1.c] == 0) {
			if (temp1.a == 0) {
				ans.push_back(temp1.c);
			}
			visited[temp1.a][temp1.b][temp1.c] = 1;
			q.push_back(temp1);
		}
		// a > c
		temp1 = temp;
		moveWater(temp1.a, temp1.c, c);
		if (visited[temp1.a][temp1.b][temp1.c] == 0) {
			if (temp1.a == 0) {
				ans.push_back(temp1.c);
			}
			visited[temp1.a][temp1.b][temp1.c] = 1;
			q.push_back(temp1);
		}
		// b > a
		temp1 = temp;
		moveWater(temp1.b, temp1.a, a);
		if (visited[temp1.a][temp1.b][temp1.c] == 0) {
			if (temp1.a == 0) {
				ans.push_back(temp1.c);
			}
			visited[temp1.a][temp1.b][temp1.c] = 1;
			q.push_back(temp1);
		}
		// b > c
		temp1 = temp;
		moveWater(temp1.b, temp1.c, c);
		if (visited[temp1.a][temp1.b][temp1.c] == 0) {
			if (temp1.a == 0) {
				ans.push_back(temp1.c);
			}
			visited[temp1.a][temp1.b][temp1.c] = 1;
			q.push_back(temp1);
		}
		// c > a
		temp1 = temp;
		moveWater(temp1.c, temp1.a, a);
		if (visited[temp1.a][temp1.b][temp1.c] == 0) {
			if (temp1.a == 0) {
				ans.push_back(temp1.c);
			}
			visited[temp1.a][temp1.b][temp1.c] = 1;
			q.push_back(temp1);
		}
		// c > b
		temp1 = temp;
		moveWater(temp1.c, temp1.b, b);
		if (visited[temp1.a][temp1.b][temp1.c] == 0) {
			if (temp1.a == 0) {
				ans.push_back(temp1.c);
			}
			visited[temp1.a][temp1.b][temp1.c] = 1;
			q.push_back(temp1);
		}
		idx += 1;
	}
	int prev = -1;
	sort(ans.begin(), ans.end());
	for (int i = 0; i < ans.size(); ++i) {
		if (prev != ans[i]) {
			cout << ans[i] << " ";
			prev = ans[i];
		}
	}
	return 0;
}