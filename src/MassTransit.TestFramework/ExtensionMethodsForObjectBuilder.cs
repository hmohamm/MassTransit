// Copyright 2007-2008 The Apache Software Foundation.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace MassTransit.TestFramework
{
	using System;
	using Rhino.Mocks;

	public static class ExtensionMethodsForObjectBuilder
	{
		public static void Add<T>(this IObjectBuilder builder, T instance)
		{
			builder.Stub(x => x.GetInstance<T>()).Return(instance);
		}

		public static void Construct<T>(this IObjectBuilder builder, Func<T> getObject)
		{
			builder.Stub(x => x.GetInstance<T>())
				.Return(default(T))
				.WhenCalled(invocation =>
					{
						// Return a unique instance of this class
						invocation.ReturnValue = getObject();
					});
		}
	}
}