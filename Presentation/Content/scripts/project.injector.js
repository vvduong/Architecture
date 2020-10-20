// namespace
var Vpa_Project = Vpa_Project || {};

Vpa_Project.Injector = (function () {
    'use strict';

    var dependencies = {}
        ,
        addDependency = function (key, dependency) {
            dependencies[key] = dependency;
        }
        ,
        resolveDependency = function (constructor, params) {
            var dependencies = resolveParamDependencies(constructor, params);

            function mediatConstructor() {
                constructor.apply(this, dependencies);
            }

            mediatConstructor.prototype = constructor.prototype;

            return new mediatConstructor();
        }
        ,
        resolveParamDependencies = function (constructor, params) {
            params = params || {};

            var args = getArguments(constructor);
            var paramDependencies = [];

            for (var i = 0; i < args.length; i++) {
                var paramName = args[i];
                var dependency = dependencies[paramName];

                var resolve = params[paramName] || (typeof dependency === 'function' ? dependency() : undefined);

                paramDependencies.push(resolve);
            }

            return paramDependencies;
        }
        ,
        getArguments = function (func) {
            return func.toString().match(/^function\s*[^\(]*\(\s*([^\)]*)\)/m)[1].split(',').map(function (arg) {
                return arg.trim();
            });
        }

    return {
        addDependency: addDependency
        ,
        resolveDependency: resolveDependency
    }
})();

// debugging
//# sourceURL=lacviet.sureportal.injector.js