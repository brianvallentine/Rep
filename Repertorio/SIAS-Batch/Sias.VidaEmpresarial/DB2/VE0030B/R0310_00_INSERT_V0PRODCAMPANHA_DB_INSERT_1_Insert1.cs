using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0030B
{
    public class R0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1_Insert1 : QueryBasis<R0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0PRODCAMPANHA
            VALUES (:V0PRODC-DTOPER,
            :V0PRODC-COD-AGENC,
            :V0PRODC-CODPRODAZ,
            :V0PRODC-NUM-MATRIC,
            :V0PRODC-COD-OPER,
            :V0PRODC-COD-FONTE,
            :V0PRODC-NUM-PROPO,
            :V0PRODC-QTD-REALI,
            :V0PRODC-VL-COMI-RE,
            :V0PRODC-COD-PLANO,
            :V0PRODC-DT-REFER,
            :V0PRODC-SIT-CAMPAN,
            :V0PRODC-SIT-INTERF,
            :V0PRODC-SIT-DIARIO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0PRODCAMPANHA VALUES ({FieldThreatment(this.V0PRODC_DTOPER)}, {FieldThreatment(this.V0PRODC_COD_AGENC)}, {FieldThreatment(this.V0PRODC_CODPRODAZ)}, {FieldThreatment(this.V0PRODC_NUM_MATRIC)}, {FieldThreatment(this.V0PRODC_COD_OPER)}, {FieldThreatment(this.V0PRODC_COD_FONTE)}, {FieldThreatment(this.V0PRODC_NUM_PROPO)}, {FieldThreatment(this.V0PRODC_QTD_REALI)}, {FieldThreatment(this.V0PRODC_VL_COMI_RE)}, {FieldThreatment(this.V0PRODC_COD_PLANO)}, {FieldThreatment(this.V0PRODC_DT_REFER)}, {FieldThreatment(this.V0PRODC_SIT_CAMPAN)}, {FieldThreatment(this.V0PRODC_SIT_INTERF)}, {FieldThreatment(this.V0PRODC_SIT_DIARIO)})";

            return query;
        }
        public string V0PRODC_DTOPER { get; set; }
        public string V0PRODC_COD_AGENC { get; set; }
        public string V0PRODC_CODPRODAZ { get; set; }
        public string V0PRODC_NUM_MATRIC { get; set; }
        public string V0PRODC_COD_OPER { get; set; }
        public string V0PRODC_COD_FONTE { get; set; }
        public string V0PRODC_NUM_PROPO { get; set; }
        public string V0PRODC_QTD_REALI { get; set; }
        public string V0PRODC_VL_COMI_RE { get; set; }
        public string V0PRODC_COD_PLANO { get; set; }
        public string V0PRODC_DT_REFER { get; set; }
        public string V0PRODC_SIT_CAMPAN { get; set; }
        public string V0PRODC_SIT_INTERF { get; set; }
        public string V0PRODC_SIT_DIARIO { get; set; }

        public static void Execute(R0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1_Insert1 r0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1_Insert1)
        {
            var ths = r0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0310_00_INSERT_V0PRODCAMPANHA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}