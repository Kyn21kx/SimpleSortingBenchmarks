import random

def GenerateNumbers(el=100000):
    numbers = [random.randrange(0, el) for i in range(el)]
    return numbers

def BubbleSort(arr):
    ordered = True
    while True:
        #Iterate through the array
        for i in range(len(arr)):
            if i < len(arr) - 1:
                #CheckIndex if the positions are ordered
                if arr[i] > arr[i + 1]:
                    #Swap
                    temp = arr[i]
                    arr[i] = arr[i + 1]
                    arr[i + 1] = temp
                    ordered = False
        if ordered:
            break
        else:
            ordered = True

def InsertionSort(arr):
    for i in range(1, len(arr)):
        #Check if it is smaller than the previous one
        InsertBackIndex(arr, i)

def InsertBackIndex(arr, index):
    for i in range(index, 0, -1):
        if arr[i] >= arr[i - 1]:
            return
        #Swap the elements
        temp = arr[i]
        arr[i] = arr[i - 1]
        arr[i - 1] = temp

def SelectionSort(arr):
    #Get the subarray
    for i in range(len(arr)):
        currMin = i
        for j in range(i + 1, len(arr)):
            if arr[currMin] > arr[j]:
                currMin = j
        #Swap
        temp = arr[i]
        arr[i] = arr[currMin]
        arr[currMin] = temp

def MergeSort(arr):
    if len(arr) > 1:
        mid = len(arr) // 2
        left = arr[:mid]
        right = arr[mid:]

        MergeSort(left)
        MergeSort(right)

        i = 0
        j = 0
        
        # Iterator for the main list
        elementIndex = 0
        
        while i < len(left) and j < len(right):
            if left[i] < right[j]:
              # The value from the left half has been used
              arr[elementIndex] = left[i]
              # Move the iterator forward
              i += 1
            else:
                arr[elementIndex] = right[j]
                j += 1

            elementIndex += 1


        while i < len(left):
            arr[elementIndex] = left[i]
            i += 1
            elementIndex += 1

        while j < len(right):
            arr[elementIndex]=right[j]
            j += 1
            elementIndex += 1