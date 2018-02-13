StrictEmit
==========

StrictEmit is a small library that improves the API of the `ILGenerator` class, adding properly typed extensions and 
overloads for every CIL instruction, along with inline XML documentation for them.

This stands in contrast to the typical `ILGenerator::Emit` method, which allows the developer to emit invalid IL
instructions by using the incorrect overload.

Furthermore, the library provides builtin instruction optimization, picking the best instruction for those calls which
have optimized versions for certain conditions (`Ldarg` with indexes 0-3, etc).

All extension methods follow the naming pattern of `Emit<InstructionEffect>`.

## Installing
Get it on [NuGet][1].


[1]: https://www.nuget.org/packages/StrictEmit