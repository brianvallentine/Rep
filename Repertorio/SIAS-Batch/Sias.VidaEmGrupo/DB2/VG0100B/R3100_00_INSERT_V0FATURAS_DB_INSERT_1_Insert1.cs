using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0100B
{
    public class R3100_00_INSERT_V0FATURAS_DB_INSERT_1_Insert1 : QueryBasis<R3100_00_INSERT_V0FATURAS_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0FATURAS
            VALUES (:V0FATR-NUM-APOL ,
            :V0FATR-COD-SUBG ,
            :V0FATR-NUM-FATUR ,
            :V0FATR-COD-OPER ,
            :V0FATR-TIPO-ENDOS ,
            :V0FATR-NUM-ENDOS ,
            :V0FATR-VAL-FATURA ,
            :V0FATR-COD-FONTE ,
            :V0FATR-NUM-RCAP ,
            :V0FATR-VAL-RCAP ,
            :V0FATR-DATA-INIVIG ,
            :V0FATR-DATA-TERVIG ,
            :V0FATR-SIT-REG ,
            :V0FATR-DATA-FATUR:V0FATR-DATA-FATU-I,
            :V0FATR-DATA-RCAP:V0FATR-DATA-RCAP-I,
            :V0FATR-COD-EMPRESA:VIND-COD-EMP,
            :V0FATR-DATA-VENC:V0FATR-DATA-VENC-I,
            :V0FATR-VLIOCC)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0FATURAS VALUES ({FieldThreatment(this.V0FATR_NUM_APOL)} , {FieldThreatment(this.V0FATR_COD_SUBG)} , {FieldThreatment(this.V0FATR_NUM_FATUR)} , {FieldThreatment(this.V0FATR_COD_OPER)} , {FieldThreatment(this.V0FATR_TIPO_ENDOS)} , {FieldThreatment(this.V0FATR_NUM_ENDOS)} , {FieldThreatment(this.V0FATR_VAL_FATURA)} , {FieldThreatment(this.V0FATR_COD_FONTE)} , {FieldThreatment(this.V0FATR_NUM_RCAP)} , {FieldThreatment(this.V0FATR_VAL_RCAP)} , {FieldThreatment(this.V0FATR_DATA_INIVIG)} , {FieldThreatment(this.V0FATR_DATA_TERVIG)} , {FieldThreatment(this.V0FATR_SIT_REG)} ,  {FieldThreatment((this.V0FATR_DATA_FATU_I?.ToInt() == -1 ? null : this.V0FATR_DATA_FATUR))},  {FieldThreatment((this.V0FATR_DATA_RCAP_I?.ToInt() == -1 ? null : this.V0FATR_DATA_RCAP))},  {FieldThreatment((this.VIND_COD_EMP?.ToInt() == -1 ? null : this.V0FATR_COD_EMPRESA))},  {FieldThreatment((this.V0FATR_DATA_VENC_I?.ToInt() == -1 ? null : this.V0FATR_DATA_VENC))}, {FieldThreatment(this.V0FATR_VLIOCC)})";

            return query;
        }
        public string V0FATR_NUM_APOL { get; set; }
        public string V0FATR_COD_SUBG { get; set; }
        public string V0FATR_NUM_FATUR { get; set; }
        public string V0FATR_COD_OPER { get; set; }
        public string V0FATR_TIPO_ENDOS { get; set; }
        public string V0FATR_NUM_ENDOS { get; set; }
        public string V0FATR_VAL_FATURA { get; set; }
        public string V0FATR_COD_FONTE { get; set; }
        public string V0FATR_NUM_RCAP { get; set; }
        public string V0FATR_VAL_RCAP { get; set; }
        public string V0FATR_DATA_INIVIG { get; set; }
        public string V0FATR_DATA_TERVIG { get; set; }
        public string V0FATR_SIT_REG { get; set; }
        public string V0FATR_DATA_FATUR { get; set; }
        public string V0FATR_DATA_FATU_I { get; set; }
        public string V0FATR_DATA_RCAP { get; set; }
        public string V0FATR_DATA_RCAP_I { get; set; }
        public string V0FATR_COD_EMPRESA { get; set; }
        public string VIND_COD_EMP { get; set; }
        public string V0FATR_DATA_VENC { get; set; }
        public string V0FATR_DATA_VENC_I { get; set; }
        public string V0FATR_VLIOCC { get; set; }

        public static void Execute(R3100_00_INSERT_V0FATURAS_DB_INSERT_1_Insert1 r3100_00_INSERT_V0FATURAS_DB_INSERT_1_Insert1)
        {
            var ths = r3100_00_INSERT_V0FATURAS_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3100_00_INSERT_V0FATURAS_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}