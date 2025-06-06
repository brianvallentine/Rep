using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0970B
{
    public class R2050_00_SELECT_OD002_DB_SELECT_1_Query1 : QueryBasis<R2050_00_SELECT_OD002_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_CPF,
            A.NUM_DV_CPF
            INTO
            :OD002-NUM-CPF
            :OD002-NUM-DV-CPF
            FROM ODS.OD_PESSOA_FISICA A,
            SEGUROS.SI_PESS_SINISTRO B,
            SEGUROS.GE_LEG_PESS_EVENTO C
            WHERE B.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND B.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            AND B.NUM_OCORR_MOVTO = C.NUM_OCORR_MOVTO
            AND C.NUM_PESSOA = A.NUM_PESSOA
            FETCH FIRST 1 ROW ONLY
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_CPF
							,
											A.NUM_DV_CPF
											FROM ODS.OD_PESSOA_FISICA A
							,
											SEGUROS.SI_PESS_SINISTRO B
							,
											SEGUROS.GE_LEG_PESS_EVENTO C
											WHERE B.NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND B.OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											AND B.NUM_OCORR_MOVTO = C.NUM_OCORR_MOVTO
											AND C.NUM_PESSOA = A.NUM_PESSOA
											FETCH FIRST 1 ROW ONLY";

            return query;
        }
        public string OD002_NUM_CPF { get; set; }
        public string OD002_NUM_DV_CPF { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }

        public static R2050_00_SELECT_OD002_DB_SELECT_1_Query1 Execute(R2050_00_SELECT_OD002_DB_SELECT_1_Query1 r2050_00_SELECT_OD002_DB_SELECT_1_Query1)
        {
            var ths = r2050_00_SELECT_OD002_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2050_00_SELECT_OD002_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2050_00_SELECT_OD002_DB_SELECT_1_Query1();
            var i = 0;
            dta.OD002_NUM_CPF = result[i++].Value?.ToString();
            dta.OD002_NUM_DV_CPF = string.IsNullOrWhiteSpace(dta.OD002_NUM_CPF) ? "-1" : "0";
            return dta;
        }

    }
}