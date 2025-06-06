using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0006B
{
    public class R2500_00_INSERT_GE399_DB_INSERT_1_Insert1 : QueryBasis<R2500_00_INSERT_GE399_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.GE_ENDOS_RAMO_VLR_COSSEG
            VALUES (:GE399-NUM-APOLICE ,
            :GE399-NUM-ENDOSSO ,
            :GE399-COD-RAMO-COBER ,
            :GE399-COD-COSSEGURADORA ,
            :GE399-VLR-IMPSEG-CED-VAR,
            :GE399-PCT-PROP-RAMO-IS ,
            :GE399-PCT-PROP-TOTAL-IS ,
            :GE399-VLR-PRMTAR-CED-VAR,
            :GE399-PCT-PROP-RAMO-PR ,
            :GE399-PCT-PROP-TOTAL-PR ,
            :GE399-VLR-COMCOS-RAMO ,
            :GE399-PCT-PROP-COM-RAMO ,
            :GE399-PCT-PROP-COM-TOTAL,
            :GE399-NOM-PROGRAMA ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_ENDOS_RAMO_VLR_COSSEG VALUES ({FieldThreatment(this.GE399_NUM_APOLICE)} , {FieldThreatment(this.GE399_NUM_ENDOSSO)} , {FieldThreatment(this.GE399_COD_RAMO_COBER)} , {FieldThreatment(this.GE399_COD_COSSEGURADORA)} , {FieldThreatment(this.GE399_VLR_IMPSEG_CED_VAR)}, {FieldThreatment(this.GE399_PCT_PROP_RAMO_IS)} , {FieldThreatment(this.GE399_PCT_PROP_TOTAL_IS)} , {FieldThreatment(this.GE399_VLR_PRMTAR_CED_VAR)}, {FieldThreatment(this.GE399_PCT_PROP_RAMO_PR)} , {FieldThreatment(this.GE399_PCT_PROP_TOTAL_PR)} , {FieldThreatment(this.GE399_VLR_COMCOS_RAMO)} , {FieldThreatment(this.GE399_PCT_PROP_COM_RAMO)} , {FieldThreatment(this.GE399_PCT_PROP_COM_TOTAL)}, {FieldThreatment(this.GE399_NOM_PROGRAMA)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string GE399_NUM_APOLICE { get; set; }
        public string GE399_NUM_ENDOSSO { get; set; }
        public string GE399_COD_RAMO_COBER { get; set; }
        public string GE399_COD_COSSEGURADORA { get; set; }
        public string GE399_VLR_IMPSEG_CED_VAR { get; set; }
        public string GE399_PCT_PROP_RAMO_IS { get; set; }
        public string GE399_PCT_PROP_TOTAL_IS { get; set; }
        public string GE399_VLR_PRMTAR_CED_VAR { get; set; }
        public string GE399_PCT_PROP_RAMO_PR { get; set; }
        public string GE399_PCT_PROP_TOTAL_PR { get; set; }
        public string GE399_VLR_COMCOS_RAMO { get; set; }
        public string GE399_PCT_PROP_COM_RAMO { get; set; }
        public string GE399_PCT_PROP_COM_TOTAL { get; set; }
        public string GE399_NOM_PROGRAMA { get; set; }

        public static void Execute(R2500_00_INSERT_GE399_DB_INSERT_1_Insert1 r2500_00_INSERT_GE399_DB_INSERT_1_Insert1)
        {
            var ths = r2500_00_INSERT_GE399_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2500_00_INSERT_GE399_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}