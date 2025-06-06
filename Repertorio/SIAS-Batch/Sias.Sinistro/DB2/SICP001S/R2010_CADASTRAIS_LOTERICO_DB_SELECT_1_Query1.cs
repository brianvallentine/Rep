using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SICP001S
{
    public class R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1 : QueryBasis<R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT X.NUM_APOL_SINISTRO
            INTO :SINILT01-NUM-APOL-SINISTRO
            FROM SEGUROS.SINI_LOTERICO01 X,
            SEGUROS.SINISTRO_HISTORICO H
            WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            AND H.COD_OPERACAO = :SINISHIS-COD-OPERACAO
            AND H.COD_PREST_SERVICO = 0
            AND X.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT X.NUM_APOL_SINISTRO
											FROM SEGUROS.SINI_LOTERICO01 X
							,
											SEGUROS.SINISTRO_HISTORICO H
											WHERE H.NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND H.OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											AND H.COD_OPERACAO = '{this.SINISHIS_COD_OPERACAO}'
											AND H.COD_PREST_SERVICO = 0
											AND X.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO";

            return query;
        }
        public string SINILT01_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }

        public static R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1 Execute(R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1 r2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1)
        {
            var ths = r2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2010_CADASTRAIS_LOTERICO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINILT01_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            return dta;
        }

    }
}