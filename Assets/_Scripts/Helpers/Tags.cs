// It is usually good practice to setup your string datas
// as either consts or enums values
// This way, if you ever decide to correct a spelling error
// on the string value, it will be easier
// (either you do it only once with consts, or you have errors
// appearing with enums making sure you don't miss any)
public enum Tags
{
    // Adding a "None" value in an enum isn't necessary,
    // but I do personaly prefer it as it helps in
    // particular use cases
    None = 0,
    Damage = 1,
    Friendly = 2

    // When creating enums, try to always add manually a number
    // to each values of it.
    // If you don't, standard values will be added by the enum,
    // however, if you then decide to update it, it might break
    // things in your code
    // 
    // Example:
    // You create an enum with the same values as above
    // but you don't indicate the index number
    // The code will set None = 0, Damage = 1, Friendly = 2
    // But let's say for organization purposes you switch
    // Damage and Friendly in the enum list order
    // You know have this: None, Friendly, Damage
    // Well, the enum won't remember Friendly was 2,
    // and it will set it as 1, same thing on Damage
    // This means that if you use the enum index somewhere in
    // your code, it will now be the wrong value.
    // Manually adding the index number means that you can do this:
    // None = 0, Friendly = 2, Damage = 1, OtherTag = 53, etc.
    // And though they will be organized in a way that may be better
    // They'll all still stay working with the same index number
}