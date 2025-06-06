using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0002B
{
    public class R6200_00_INSERT_V0VENDASBIL_DB_INSERT_1_Insert1 : QueryBasis<R6200_00_INSERT_V0VENDASBIL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0VENDAS_BILHETES
            VALUES (:V0VEND-NUMBIL ,
            :V0VEND-AGECOBR ,
            :V0VEND-DTQITBCO ,
            :V0VEND-VLRCAP ,
            :V0VEND-DTMOVTO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0VENDAS_BILHETES VALUES ({FieldThreatment(this.V0VEND_NUMBIL)} , {FieldThreatment(this.V0VEND_AGECOBR)} , {FieldThreatment(this.V0VEND_DTQITBCO)} , {FieldThreatment(this.V0VEND_VLRCAP)} , {FieldThreatment(this.V0VEND_DTMOVTO)})";

            return query;
        }
        public string V0VEND_NUMBIL { get; set; }
        public string V0VEND_AGECOBR { get; set; }
        public string V0VEND_DTQITBCO { get; set; }
        public string V0VEND_VLRCAP { get; set; }
        public string V0VEND_DTMOVTO { get; set; }

        public static void Execute(R6200_00_INSERT_V0VENDASBIL_DB_INSERT_1_Insert1 r6200_00_INSERT_V0VENDASBIL_DB_INSERT_1_Insert1)
        {
            var ths = r6200_00_INSERT_V0VENDASBIL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R6200_00_INSERT_V0VENDASBIL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}