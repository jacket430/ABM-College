#include <iostream>
#include <iomanip>
#include <string>
#include <limits>
#include <map>
using namespace std;

class MemoryManager {
private:
    size_t totalAllocated;
    size_t totalDeallocated;
    map<void*, size_t> allocations;

public:
    MemoryManager() : totalAllocated(0), totalDeallocated(0) {}

    void* alloc(size_t size) {
        if (size <= 0) {
            cout << "Error: Invalid allocation size." << endl;
            return nullptr;
        }

        void* ptr = nullptr;
        try {
            ptr = new char[size];
            allocations[ptr] = size;
            totalAllocated += size;
            cout << "\nSuccessfully allocated " << size << " bytes" << endl;
            cout << "Memory address: " << ptr << endl;
        }
        catch (const bad_alloc& e) {
            cout << "Error: Memory allocation failed - " << e.what() << endl;
            return nullptr;
        }
        return ptr;
    }

    bool delloc(void* ptr) {
        if (ptr == nullptr) {
            cout << "Error: Cannot deallocate a null pointer." << endl;
            return false;
        }

        auto it = allocations.find(ptr);
        if (it == allocations.end()) {
            cout << "Error: Invalid pointer/memory already deallocated." << endl;
            return false;
        }

        size_t size = it->second;
        delete[] static_cast<char*>(ptr);
        totalDeallocated += size;
        allocations.erase(it);
        
        cout << "\nSuccessfully deallocated " << size << " bytes" << endl;
        cout << "Memory address: " << ptr << endl;
        return true;
    }

    void displayMemoryUsage(const map<int, void*>& blocks) const {
        cout << "\n-- Memory Usage Details --" << endl;
        cout << "Total Allocated: " << totalAllocated << " bytes" << endl;
        cout << "Total Deallocated: " << totalDeallocated << " bytes" << endl;
        cout << "Current Memory Usage: " << (totalAllocated - totalDeallocated) << " bytes" << endl;
        cout << "Active Allocations: " << allocations.size() << endl;
        cout << "Active Block IDs: ";
        
        for (const auto& block : blocks) {
            cout << block.first << " ";
        }
        cout << endl;
        cout << "------------------------\n" << endl;
    }

    ~MemoryManager() {
        if (!allocations.empty()) {
            cout << "Warning: Memory leaks detected!" << endl;
            cout << "Number of unfreed allocations: " << allocations.size() << endl;
        }
    }
};

int main() {
    MemoryManager memMgr;
    int choice;
    map<int, void*> allocatedBlocks;
    int blockCounter = 0;

    do {
        cout << "Memory Management System\n======= Menu =======" << endl;
        cout << "1.) Allocate memory" << endl;
        cout << "2.) Deallocate memory" << endl;
        cout << "3.) Display memory usage" << endl;
        cout << "4.) Exit" << endl;
        cout << "====================" << endl;        
        cout << "Enter a selection: ";
        cin >> choice;

        if (cin.fail() || choice < 1 || choice > 4) {
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
            cout << "Invalid entry. Please enter a valid selection." << endl;
            continue;
        }

        switch (choice) {
            case 1: {
                size_t size;
                cout << "Enter size to allocate (in bytes): ";
                cin >> size;

                if (cin.fail() || size <= 0) {
                    cin.clear();
                    cin.ignore(numeric_limits<streamsize>::max(), '\n');
                    cout << "Error: Invalid size specified." << endl;
                    break;
                }

                void* ptr = memMgr.alloc(size);
                if (ptr != nullptr) {
                    allocatedBlocks[++blockCounter] = ptr;
                    cout << "Block ID: " << blockCounter << endl;
                }
                memMgr.displayMemoryUsage(allocatedBlocks);
                break;
            }
            case 2: {
                int blockId;
                cout << "Enter Block ID to deallocate: ";
                cin >> blockId;

                auto it = allocatedBlocks.find(blockId);
                if (it == allocatedBlocks.end()) {
                    cout << "Error: Invalid Block ID." << endl;
                    break;
                }

                if (memMgr.delloc(it->second)) {
                    allocatedBlocks.erase(it);
                }
                memMgr.displayMemoryUsage(allocatedBlocks);
                break;
            }
            case 3: {
                memMgr.displayMemoryUsage(allocatedBlocks);
                break;
            }
            case 4:
                cout << "\nExiting Memory Management System..." << endl;
                break;
            default:
                cout << "Invalid selection. Please try again." << endl;
        }
    } while (choice != 4);

    if (!allocatedBlocks.empty()) {
        cout << "Freeing up memory..." << endl;
        for (const auto& block : allocatedBlocks) {
            memMgr.delloc(block.second);
        }
    }

    return 0;
}
