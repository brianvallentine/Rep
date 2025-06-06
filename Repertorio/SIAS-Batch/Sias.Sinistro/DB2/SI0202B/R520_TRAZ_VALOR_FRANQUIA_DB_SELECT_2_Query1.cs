using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0202B
{
    public class R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_2_Query1 : QueryBasis<R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(VAL_OPERACAO),0)
            INTO :SINISHIS-VAL-OPERACAO
            FROM SEGUROS.SINISTRO_HISTORICO H
            WHERE H.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO
            AND H.COD_OPERACAO = 2
            AND NOT EXISTS (SELECT Y.NUM_APOL_SINISTRO
            FROM SEGUROS.SINISTRO_HISTORICO Y
            WHERE Y.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
            AND Y.OCORR_HISTORICO = H.OCORR_HISTORICO
            AND Y.COD_OPERACAO = 1050)
            AND ( H.NOM_PROGRAMA <> 'SI0170B'
            OR H.NOM_PROGRAMA IS NULL)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(VAL_OPERACAO)
							,0)
											FROM SEGUROS.SINISTRO_HISTORICO H
											WHERE H.NUM_APOL_SINISTRO = '{this.SINISMES_NUM_APOL_SINISTRO}'
											AND H.COD_OPERACAO = 2
											AND NOT EXISTS
							(SELECT  Y.NUM_APOL_SINISTRO
											FROM SEGUROS.SINISTRO_HISTORICO Y
											WHERE Y.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
											AND Y.OCORR_HISTORICO = H.OCORR_HISTORICO
											AND Y.COD_OPERACAO = 1050)
											AND ( H.NOM_PROGRAMA <> 'SI0170B'
											OR H.NOM_PROGRAMA IS NULL)
											WITH UR";

            return query;
        }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }

        public static R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_2_Query1 Execute(R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_2_Query1 r520_TRAZ_VALOR_FRANQUIA_DB_SELECT_2_Query1)
        {
            var ths = r520_TRAZ_VALOR_FRANQUIA_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R520_TRAZ_VALOR_FRANQUIA_DB_SELECT_2_Query1();
            var i = 0;
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}