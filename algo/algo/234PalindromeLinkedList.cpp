#include<iostream>
#include<stack>

using std::cout;
using std::endl;
using std::stack;

struct ListNode {
    int val;
    ListNode* next;
    ListNode() : val(0), next(nullptr) {}
    ListNode(int x) : val(x), next(nullptr) {}
    ListNode(int x, ListNode* next) : val(x), next(next) {}
    
};

class Solution {
public:
    bool isPalindrome(ListNode* head) {
        int size = 0;
        ListNode* temp = head;
        while (temp != nullptr) {
            temp = temp->next;
            ++size;
        }
        if (size <= 1)
            return true;

        stack<int> chkPal;
        temp = head;
        for (int i = 0; i < size; ++i) {
            if (size % 2 != 0 && i == size / 2) {

            }
            else if (i < size / 2)
                chkPal.push(temp->val);
            else {
                int num = chkPal.top();
                chkPal.pop();
                if (num != temp->val)
                    return false;    
            }
            temp = temp->next;
        }
        return true;
    }
};

int main() {
    ListNode* a = new ListNode(0);
    a->next = new ListNode(1);
    ListNode* b = new ListNode(1, a);
    Solution t;
    cout << t.isPalindrome(b) << endl;
    return 0;
}