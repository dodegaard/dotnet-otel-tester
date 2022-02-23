# dotnet-otel-tester
Test app to generate traffic for tracing for OpenTelemetry spans

Purpose is to make a database call and an api call in a loop to generate spans.

Steps to use this tester
1. Find a simple postgres db and get a connection string.  Place into the connString variable in Program.cs
2. This queries Github .NET repos but can get rate limited easily.  Feel free to change to your own REST api.
3. Run the program on a machine with an auto-tracer and collector pointed to APM instance
4. Check for correlated GEt and data traces

Things to change
1. Target Framework (this is using net5.0)
2. Version of tracer library
