OrderByThenBy();

void OrderByThenBy() {
  string[] names = {"Dwight", "Michael", "Kevin", "Jim", "Pam", "Creed"};

  IOrderedEnumerable<string>? orderedNames = names.OrderBy(name => name.Length)
       .ThenBy(name => name);

  WriteEnum(orderedNames);
}

void WriteEnum<T>(IEnumerable<T> enumerable) {
  foreach (var item in enumerable) {
    System.Console.WriteLine(item);
  }
}

void WhereWithDelegate() {
  var nums = Enumerable.Range(1,10);
  var numsBiggerThanFive = nums.Where(numbersBiggerThanFive);

  foreach ( var num in numsBiggerThanFive) {
    System.Console.WriteLine(num);
  }
}

bool numbersBiggerThanFive(int arg) {
  return arg > 5;
}

static void Select() {
  var x = Enumerable.Range(1, 5)
                    .Select((num, index) => new { index, num = num * num });

  Console.WriteLine("Square table:");

  foreach (var item in x)
  {
    Console.WriteLine($"Square({item.index + 1}) = {item.num}");
  }
}

static void Except() {
  var numbers1 = Enumerable.Range(1, 5);
  var numbers2 = Enumerable.Range(3, 8);

  IEnumerable<int> onlyInFirstSet = numbers1.Except(numbers2);

  foreach (var number in onlyInFirstSet) {
    Console.WriteLine($"{number}  ");
  }
}

static void Zip() { 
  var nums = Enumerable.Range(1,3);
  string[] str = {"one", "two", "three"};

  var numsAndStrs = nums.Zip(str, (tuppleInt, tuppleStr) => tuppleInt + " - " + tuppleStr);

  foreach(var item in numsAndStrs) { 
    Console.WriteLine(item);
  }
}