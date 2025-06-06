using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0009B
{
    public class R1700_00_SELECT_GE399_DB_SELECT_1_Query1 : QueryBasis<R1700_00_SELECT_GE399_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            VALUE(SUM(VLR_PRMTAR_CED_VAR),+0),
            VALUE(SUM(PCT_PROP_TOTAL_PR),+0),
            VALUE(SUM(VLR_COMCOS_RAMO),+0),
            VALUE(SUM(PCT_PROP_COM_TOTAL),+0)
            INTO :GE399-VLR-PRMTAR-CED-VAR,
            :GE399-PCT-PROP-TOTAL-PR,
            :GE399-VLR-COMCOS-RAMO,
            :GE399-PCT-PROP-COM-TOTAL
            FROM SEGUROS.GE_ENDOS_RAMO_VLR_COSSEG
            WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE
            AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO
            AND COD_COSSEGURADORA = :APOLCOSS-COD-COSSEGURADORA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(SUM(VLR_PRMTAR_CED_VAR)
							,+0)
							,
											VALUE(SUM(PCT_PROP_TOTAL_PR)
							,+0)
							,
											VALUE(SUM(VLR_COMCOS_RAMO)
							,+0)
							,
											VALUE(SUM(PCT_PROP_COM_TOTAL)
							,+0)
											FROM SEGUROS.GE_ENDOS_RAMO_VLR_COSSEG
											WHERE NUM_APOLICE = '{this.ENDOSSOS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.ENDOSSOS_NUM_ENDOSSO}'
											AND COD_COSSEGURADORA = '{this.APOLCOSS_COD_COSSEGURADORA}'";

            return query;
        }
        public string GE399_VLR_PRMTAR_CED_VAR { get; set; }
        public string GE399_PCT_PROP_TOTAL_PR { get; set; }
        public string GE399_VLR_COMCOS_RAMO { get; set; }
        public string GE399_PCT_PROP_COM_TOTAL { get; set; }
        public string APOLCOSS_COD_COSSEGURADORA { get; set; }
        public string ENDOSSOS_NUM_APOLICE { get; set; }
        public string ENDOSSOS_NUM_ENDOSSO { get; set; }

        public static R1700_00_SELECT_GE399_DB_SELECT_1_Query1 Execute(R1700_00_SELECT_GE399_DB_SELECT_1_Query1 r1700_00_SELECT_GE399_DB_SELECT_1_Query1)
        {
            var ths = r1700_00_SELECT_GE399_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1700_00_SELECT_GE399_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1700_00_SELECT_GE399_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE399_VLR_PRMTAR_CED_VAR = result[i++].Value?.ToString();
            dta.GE399_PCT_PROP_TOTAL_PR = result[i++].Value?.ToString();
            dta.GE399_VLR_COMCOS_RAMO = result[i++].Value?.ToString();
            dta.GE399_PCT_PROP_COM_TOTAL = result[i++].Value?.ToString();
            return dta;
        }

    }
}