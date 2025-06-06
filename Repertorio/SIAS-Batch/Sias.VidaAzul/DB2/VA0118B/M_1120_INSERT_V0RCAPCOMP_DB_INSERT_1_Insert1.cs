using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1 : QueryBasis<M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0RCAPCOMP
            VALUES (:V1RCAC-FONTE ,
            :V1RCAC-NRRCAP ,
            :V1RCAC-NRRCAPCO ,
            :V1RCAC-OPERACAO ,
            :SISTEMA-DTMOVABE ,
            CURRENT TIME,
            :V1RCAC-SITUACAO ,
            :V1RCAC-BCOAVISO ,
            :V1RCAC-AGEAVISO ,
            :V1RCAC-NRAVISO ,
            :V1RCAC-VLRCAP ,
            :V1RCAC-DATARCAP ,
            :V1RCAC-DTCADAST ,
            :V1RCAC-SITCONTB ,
            :V1RCAC-COD-EMPRESA ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0RCAPCOMP VALUES ({FieldThreatment(this.V1RCAC_FONTE)} , {FieldThreatment(this.V1RCAC_NRRCAP)} , {FieldThreatment(this.V1RCAC_NRRCAPCO)} , {FieldThreatment(this.V1RCAC_OPERACAO)} , {FieldThreatment(this.SISTEMA_DTMOVABE)} , CURRENT TIME, {FieldThreatment(this.V1RCAC_SITUACAO)} , {FieldThreatment(this.V1RCAC_BCOAVISO)} , {FieldThreatment(this.V1RCAC_AGEAVISO)} , {FieldThreatment(this.V1RCAC_NRAVISO)} , {FieldThreatment(this.V1RCAC_VLRCAP)} , {FieldThreatment(this.V1RCAC_DATARCAP)} , {FieldThreatment(this.V1RCAC_DTCADAST)} , {FieldThreatment(this.V1RCAC_SITCONTB)} , {FieldThreatment(this.V1RCAC_COD_EMPRESA)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V1RCAC_FONTE { get; set; }
        public string V1RCAC_NRRCAP { get; set; }
        public string V1RCAC_NRRCAPCO { get; set; }
        public string V1RCAC_OPERACAO { get; set; }
        public string SISTEMA_DTMOVABE { get; set; }
        public string V1RCAC_SITUACAO { get; set; }
        public string V1RCAC_BCOAVISO { get; set; }
        public string V1RCAC_AGEAVISO { get; set; }
        public string V1RCAC_NRAVISO { get; set; }
        public string V1RCAC_VLRCAP { get; set; }
        public string V1RCAC_DATARCAP { get; set; }
        public string V1RCAC_DTCADAST { get; set; }
        public string V1RCAC_SITCONTB { get; set; }
        public string V1RCAC_COD_EMPRESA { get; set; }

        public static void Execute(M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1 m_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1)
        {
            var ths = m_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1120_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}