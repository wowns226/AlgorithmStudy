#include <iostream>
#include <string>
#include <cmath>

using namespace std;

int main() {
	int n;
	int ans = -1;
	cin >> n;
	int idx = n;

	while (ans == -1) {
		if (idx == 1) {
			idx += 1;
			continue;
		}
		string deci = to_string(idx);
		bool ispal = true;
		bool ispri = true;
		for (int i = 0; i <= deci.length() / 2; ++i) {
			if (deci[i] != deci[deci.length() - 1 - i]) {
				ispal = false;
				break;
			}
		}
		if (ispal) {
			for (int i = 2; i <= sqrt(idx); ++i) {
				if (idx % i == 0) {
					ispri = false;
					break;
				}
			}

		}
		if (ispal && ispri) {
			ans = idx;
			break;
		}
		++idx;
	}
	cout << ans;
}