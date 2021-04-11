from algorithms import *
import time

bubbleTimes = []
insertionTimes = []
selectionTimes = []
mergeTimes = []
defaultTimes = []

def PrintResults():
    print("Bubble sort took in average: " + str(Average(bubbleTimes)) + "s")
    print("Insertion sort took in average: " + str(Average(insertionTimes)) + "s")
    print("Selection sort took in average: " + str(Average(selectionTimes)) + "s")
    print("Merge sort took in average: " + str(Average(mergeTimes)) + "s")
    print("Default sort took in average: " + str(Average(defaultTimes)) + "s")

def Average(arr):
    sum = 0
    for i in range(len(arr)):
        sum += arr[i]
    return sum

for i in range(20):
    print("Generating random numbers...")
    randNums = GenerateNumbers(el=1000)
    cacheNums = randNums.copy()
    print(randNums)
    
    print("Sorting with bubble sort...")
    start = time.time()
    BubbleSort(randNums)
    bubbleTimes.append(time.time() - start)
    print(randNums)
    
    randNums = cacheNums.copy()
    
    print("Sorting with insertion sort...")
    start = time.time()
    InsertionSort(randNums)
    insertionTimes.append(time.time() - start)
    print(randNums)
    
    randNums = cacheNums.copy()
    
    print("Sorting with selection sort...")
    start = time.time()
    SelectionSort(randNums)
    selectionTimes.append(time.time() - start)
    print(randNums)
    
    randNums = cacheNums.copy()

    print("Sorting with merge sort...")
    start = time.time()
    MergeSort(randNums)
    mergeTimes.append(time.time() - start)
    print(randNums)
    
    randNums = cacheNums.copy()
    
    print("Sorting with default sort...")
    start = time.time()
    randNums = sorted(randNums)
    defaultTimes.append(time.time() - start)
    print(randNums)

PrintResults()