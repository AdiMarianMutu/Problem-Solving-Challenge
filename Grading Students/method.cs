static int[] gradingStudents(int[] grades) {
    for (int i = 0; i < grades.Length; i++) {
        if (grades[i] > 37 && grades[i] < 100) {
            int diff  = (5 - (grades[i] % 5));
            grades[i] = grades[i] + (diff < 3 ? diff : 0);
        }
    }
        
    return grades;
}
