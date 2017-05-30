    Bridge.define("Bridge.Newtonsoft.Json.Formatting", {
        $kind: "enum",
        statics: {
            fields: {
                None: 0,
                Indented: 1
            }
        }
    });

    Bridge.define("Bridge.Newtonsoft.Json.JsonSerializerSettings", {
        statics: {
            fields: {
                DefaultNullValueHandling: 0,
                DefaultTypeNameHandling: 0
            },
            ctors: {
                init: function () {
                    this.DefaultNullValueHandling = Bridge.Newtonsoft.Json.NullValueHandling.Include;
                    this.DefaultTypeNameHandling = Bridge.Newtonsoft.Json.TypeNameHandling.None;
                }
            }
        },
        fields: {
            _typeNameHandling: null,
            _nullValueHandling: null
        },
        props: {
            NullValueHandling: {
                get: function () {
                    var $t;
                    return ($t = this._nullValueHandling, $t != null ? $t : Bridge.Newtonsoft.Json.JsonSerializerSettings.DefaultNullValueHandling);
                },
                set: function (value) {
                    this._nullValueHandling = value;
                }
            },
            TypeNameHandling: {
                get: function () {
                    var $t;
                    return ($t = this._typeNameHandling, $t != null ? $t : Bridge.Newtonsoft.Json.JsonSerializerSettings.DefaultTypeNameHandling);
                },
                set: function (value) {
                    this._typeNameHandling = value;
                }
            },
            ContractResolver: null
        }
    });

    Bridge.define("Bridge.Newtonsoft.Json.NullValueHandling", {
        $kind: "enum",
        statics: {
            fields: {
                Include: 0,
                Ignore: 1
            }
        }
    });

    Bridge.define("Bridge.Newtonsoft.Json.Serialization.IContractResolver", {
        $kind: "interface"
    });

    Bridge.define("Bridge.Newtonsoft.Json.TypeNameHandling", {
        $kind: "enum",
        statics: {
            fields: {
                None: 0,
                Objects: 1,
                Arrays: 2,
                All: 3,
                Auto: 4
            }
        },
        $flags: true
    });

    Bridge.define("Bridge.Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver", {
        inherits: [Bridge.Newtonsoft.Json.Serialization.IContractResolver]
    });

