using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0862B
{
    public class R050_GRAVA_COLUNA_B_DB_SELECT_1_Query1 : QueryBasis<R050_GRAVA_COLUNA_B_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(SLA.VALOR_RETENCAO),0)
            INTO :HOST-VALOR
            FROM SEGUROS.SINI_LOT_ABAT02 SLA,
            SEGUROS.SINISTRO_HISTORICO H
            WHERE SLA.DATA_MOVIMENTO BETWEEN :HOST-DATA-INICIAL
            AND :HOST-DATA-FINAL
            AND SLA.NUM_APOLICE = :HOST-APOLICE
            AND SLA.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
            AND SLA.OCORR_HISTORICO = H.OCORR_HISTORICO
            AND SLA.COD_OPERACAO = H.COD_OPERACAO
            AND SLA.COD_RETENCAO IN ( '3' , '6' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(SLA.VALOR_RETENCAO)
							,0)
											FROM SEGUROS.SINI_LOT_ABAT02 SLA
							,
											SEGUROS.SINISTRO_HISTORICO H
											WHERE SLA.DATA_MOVIMENTO BETWEEN '{this.HOST_DATA_INICIAL}'
											AND '{this.HOST_DATA_FINAL}'
											AND SLA.NUM_APOLICE = '{this.HOST_APOLICE}'
											AND SLA.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
											AND SLA.OCORR_HISTORICO = H.OCORR_HISTORICO
											AND SLA.COD_OPERACAO = H.COD_OPERACAO
											AND SLA.COD_RETENCAO IN ( '3' 
							, '6' )";

            return query;
        }
        public string HOST_VALOR { get; set; }
        public string HOST_DATA_INICIAL { get; set; }
        public string HOST_DATA_FINAL { get; set; }
        public string HOST_APOLICE { get; set; }

        public static R050_GRAVA_COLUNA_B_DB_SELECT_1_Query1 Execute(R050_GRAVA_COLUNA_B_DB_SELECT_1_Query1 r050_GRAVA_COLUNA_B_DB_SELECT_1_Query1)
        {
            var ths = r050_GRAVA_COLUNA_B_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R050_GRAVA_COLUNA_B_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R050_GRAVA_COLUNA_B_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_VALOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}