using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0890B
{
    public class R111040_LE_OUTROS_COB_DB_SELECT_1_Query1 : QueryBasis<R111040_LE_OUTROS_COB_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            IMP_SEGURADA_IX,
            DATA_INIVIGENCIA,
            DATA_TERVIGENCIA
            INTO
            :OUTROCOB-IMP-SEGURADA-IX,
            :OUTROCOB-DATA-INIVIGENCIA,
            :OUTROCOB-DATA-TERVIGENCIA
            FROM SEGUROS.OUTROS_COBERTURAS B
            WHERE B.NUM_APOLICE = :OUTROCOB-NUM-APOLICE
            AND B.RAMO_COBERTURA = :OUTROCOB-RAMO-COBERTURA
            AND B.MODALI_COBERTURA = :OUTROCOB-MODALI-COBERTURA
            AND B.COD_COBERTURA = :OUTROCOB-COD-COBERTURA
            AND B.DATA_TERVIGENCIA >= :SINISMES-DATA-OCORRENCIA
            AND B.DATA_INIVIGENCIA =
            (SELECT MAX(O.DATA_INIVIGENCIA)
            FROM SEGUROS.OUTROS_COBERTURAS O
            WHERE O.NUM_APOLICE = B.NUM_APOLICE
            AND O.RAMO_COBERTURA = B.RAMO_COBERTURA
            AND O.MODALI_COBERTURA = B.MODALI_COBERTURA
            AND O.COD_COBERTURA = B.COD_COBERTURA
            AND O.DATA_INIVIGENCIA <= :SINISMES-DATA-OCORRENCIA
            AND O.DATA_TERVIGENCIA >= :SINISMES-DATA-OCORRENCIA)
            AND B.TIMESTAMP =
            (SELECT MAX(Q.TIMESTAMP)
            FROM SEGUROS.OUTROS_COBERTURAS Q
            WHERE Q.NUM_APOLICE = B.NUM_APOLICE
            AND Q.RAMO_COBERTURA = B.RAMO_COBERTURA
            AND Q.MODALI_COBERTURA = B.MODALI_COBERTURA
            AND Q.COD_COBERTURA = B.COD_COBERTURA
            AND Q.DATA_INIVIGENCIA <= :SINISMES-DATA-OCORRENCIA
            AND Q.DATA_TERVIGENCIA >= :SINISMES-DATA-OCORRENCIA)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											IMP_SEGURADA_IX
							,
											DATA_INIVIGENCIA
							,
											DATA_TERVIGENCIA
											FROM SEGUROS.OUTROS_COBERTURAS B
											WHERE B.NUM_APOLICE = '{this.OUTROCOB_NUM_APOLICE}'
											AND B.RAMO_COBERTURA = '{this.OUTROCOB_RAMO_COBERTURA}'
											AND B.MODALI_COBERTURA = '{this.OUTROCOB_MODALI_COBERTURA}'
											AND B.COD_COBERTURA = '{this.OUTROCOB_COD_COBERTURA}'
											AND B.DATA_TERVIGENCIA >= '{this.SINISMES_DATA_OCORRENCIA}'
											AND B.DATA_INIVIGENCIA =
											(SELECT MAX(O.DATA_INIVIGENCIA)
											FROM SEGUROS.OUTROS_COBERTURAS O
											WHERE O.NUM_APOLICE = B.NUM_APOLICE
											AND O.RAMO_COBERTURA = B.RAMO_COBERTURA
											AND O.MODALI_COBERTURA = B.MODALI_COBERTURA
											AND O.COD_COBERTURA = B.COD_COBERTURA
											AND O.DATA_INIVIGENCIA <= '{this.SINISMES_DATA_OCORRENCIA}'
											AND O.DATA_TERVIGENCIA >= '{this.SINISMES_DATA_OCORRENCIA}')
											AND B.TIMESTAMP =
											(SELECT MAX(Q.TIMESTAMP)
											FROM SEGUROS.OUTROS_COBERTURAS Q
											WHERE Q.NUM_APOLICE = B.NUM_APOLICE
											AND Q.RAMO_COBERTURA = B.RAMO_COBERTURA
											AND Q.MODALI_COBERTURA = B.MODALI_COBERTURA
											AND Q.COD_COBERTURA = B.COD_COBERTURA
											AND Q.DATA_INIVIGENCIA <= '{this.SINISMES_DATA_OCORRENCIA}'
											AND Q.DATA_TERVIGENCIA >= '{this.SINISMES_DATA_OCORRENCIA}')";

            return query;
        }
        public string OUTROCOB_IMP_SEGURADA_IX { get; set; }
        public string OUTROCOB_DATA_INIVIGENCIA { get; set; }
        public string OUTROCOB_DATA_TERVIGENCIA { get; set; }
        public string OUTROCOB_MODALI_COBERTURA { get; set; }
        public string SINISMES_DATA_OCORRENCIA { get; set; }
        public string OUTROCOB_RAMO_COBERTURA { get; set; }
        public string OUTROCOB_COD_COBERTURA { get; set; }
        public string OUTROCOB_NUM_APOLICE { get; set; }

        public static R111040_LE_OUTROS_COB_DB_SELECT_1_Query1 Execute(R111040_LE_OUTROS_COB_DB_SELECT_1_Query1 r111040_LE_OUTROS_COB_DB_SELECT_1_Query1)
        {
            var ths = r111040_LE_OUTROS_COB_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R111040_LE_OUTROS_COB_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R111040_LE_OUTROS_COB_DB_SELECT_1_Query1();
            var i = 0;
            dta.OUTROCOB_IMP_SEGURADA_IX = result[i++].Value?.ToString();
            dta.OUTROCOB_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.OUTROCOB_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}