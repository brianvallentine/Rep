using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0003B
{
    public class R4650_00_INSERT_V0CONTROCNAB_DB_INSERT_1_Insert1 : QueryBasis<R4650_00_INSERT_V0CONTROCNAB_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0CONTROCNAB
            VALUES (:V0CNAB-COD-EMP ,
            :V0CNAB-ORGAO ,
            :V0CNAB-NRCTACED ,
            :V0CNAB-TIPOCOB ,
            :V0CNAB-DTMOVTO ,
            :V0CNAB-DATCEF ,
            :V0CNAB-NRSEQ ,
            :V0CNAB-QTDREG ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0CONTROCNAB VALUES ({FieldThreatment(this.V0CNAB_COD_EMP)} , {FieldThreatment(this.V0CNAB_ORGAO)} , {FieldThreatment(this.V0CNAB_NRCTACED)} , {FieldThreatment(this.V0CNAB_TIPOCOB)} , {FieldThreatment(this.V0CNAB_DTMOVTO)} , {FieldThreatment(this.V0CNAB_DATCEF)} , {FieldThreatment(this.V0CNAB_NRSEQ)} , {FieldThreatment(this.V0CNAB_QTDREG)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0CNAB_COD_EMP { get; set; }
        public string V0CNAB_ORGAO { get; set; }
        public string V0CNAB_NRCTACED { get; set; }
        public string V0CNAB_TIPOCOB { get; set; }
        public string V0CNAB_DTMOVTO { get; set; }
        public string V0CNAB_DATCEF { get; set; }
        public string V0CNAB_NRSEQ { get; set; }
        public string V0CNAB_QTDREG { get; set; }

        public static void Execute(R4650_00_INSERT_V0CONTROCNAB_DB_INSERT_1_Insert1 r4650_00_INSERT_V0CONTROCNAB_DB_INSERT_1_Insert1)
        {
            var ths = r4650_00_INSERT_V0CONTROCNAB_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4650_00_INSERT_V0CONTROCNAB_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}