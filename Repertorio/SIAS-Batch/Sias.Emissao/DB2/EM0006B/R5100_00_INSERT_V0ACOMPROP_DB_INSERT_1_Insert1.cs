using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0006B
{
    public class R5100_00_INSERT_V0ACOMPROP_DB_INSERT_1_Insert1 : QueryBasis<R5100_00_INSERT_V0ACOMPROP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0ACOMPROP
            VALUES (:V0APRO-FONTE ,
            :V0APRO-NRPROPOS ,
            :V0APRO-OPERACAO ,
            :V0APRO-DATOPR ,
            :V0APRO-HORAOPER ,
            :V0APRO-OCORHIST ,
            :V0APRO-CODUSU ,
            :V0APRO-COD-EMPRESA:VIND-COD-EMP,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0ACOMPROP VALUES ({FieldThreatment(this.V0APRO_FONTE)} , {FieldThreatment(this.V0APRO_NRPROPOS)} , {FieldThreatment(this.V0APRO_OPERACAO)} , {FieldThreatment(this.V0APRO_DATOPR)} , {FieldThreatment(this.V0APRO_HORAOPER)} , {FieldThreatment(this.V0APRO_OCORHIST)} , {FieldThreatment(this.V0APRO_CODUSU)} ,  {FieldThreatment((this.VIND_COD_EMP?.ToInt() == -1 ? null : this.V0APRO_COD_EMPRESA))}, CURRENT TIMESTAMP)";

            return query;
        }
        public string V0APRO_FONTE { get; set; }
        public string V0APRO_NRPROPOS { get; set; }
        public string V0APRO_OPERACAO { get; set; }
        public string V0APRO_DATOPR { get; set; }
        public string V0APRO_HORAOPER { get; set; }
        public string V0APRO_OCORHIST { get; set; }
        public string V0APRO_CODUSU { get; set; }
        public string V0APRO_COD_EMPRESA { get; set; }
        public string VIND_COD_EMP { get; set; }

        public static void Execute(R5100_00_INSERT_V0ACOMPROP_DB_INSERT_1_Insert1 r5100_00_INSERT_V0ACOMPROP_DB_INSERT_1_Insert1)
        {
            var ths = r5100_00_INSERT_V0ACOMPROP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R5100_00_INSERT_V0ACOMPROP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}