using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.SPBVG009
{
    public class P0301_05_INICIO_DB_SELECT_1_Query1 : QueryBasis<P0301_05_INICIO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PESSOA
            , SEQ_PESSOA_HIST
            , COD_CLASSIF_RISCO
            , NUM_SCORE_RISCO
            , DTA_CLASSIF_RISCO
            , IND_PEND_APROVACAO
            , IND_DECL_AUTOMATICO
            , IND_ATLZ_FAIXA_RISCO
            INTO :VG113-COD-PESSOA
            , :VG113-SEQ-PESSOA-HIST
            , :VG113-COD-CLASSIF-RISCO
            , :VG113-NUM-SCORE-RISCO
            , :VG113-DTA-CLASSIF-RISCO
            , :VG113-IND-PEND-APROVACAO
            , :VG113-IND-DECL-AUTOMATICO
            , :VG113-IND-ATLZ-FAIXA-RISCO
            FROM SEGUROS.VG_C612_INFO_RISCO
            WHERE COD_PESSOA = :VG110-COD-PESSOA
            AND SEQ_PESSOA_HIST = :VG110-SEQ-PESSOA-HIST
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_PESSOA
											, SEQ_PESSOA_HIST
											, COD_CLASSIF_RISCO
											, NUM_SCORE_RISCO
											, DTA_CLASSIF_RISCO
											, IND_PEND_APROVACAO
											, IND_DECL_AUTOMATICO
											, IND_ATLZ_FAIXA_RISCO
											FROM SEGUROS.VG_C612_INFO_RISCO
											WHERE COD_PESSOA = '{this.VG110_COD_PESSOA}'
											AND SEQ_PESSOA_HIST = '{this.VG110_SEQ_PESSOA_HIST}'
											WITH UR";

            return query;
        }
        public string VG113_COD_PESSOA { get; set; }
        public string VG113_SEQ_PESSOA_HIST { get; set; }
        public string VG113_COD_CLASSIF_RISCO { get; set; }
        public string VG113_NUM_SCORE_RISCO { get; set; }
        public string VG113_DTA_CLASSIF_RISCO { get; set; }
        public string VG113_IND_PEND_APROVACAO { get; set; }
        public string VG113_IND_DECL_AUTOMATICO { get; set; }
        public string VG113_IND_ATLZ_FAIXA_RISCO { get; set; }
        public string VG110_SEQ_PESSOA_HIST { get; set; }
        public string VG110_COD_PESSOA { get; set; }

        public static P0301_05_INICIO_DB_SELECT_1_Query1 Execute(P0301_05_INICIO_DB_SELECT_1_Query1 p0301_05_INICIO_DB_SELECT_1_Query1)
        {
            var ths = p0301_05_INICIO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P0301_05_INICIO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P0301_05_INICIO_DB_SELECT_1_Query1();
            var i = 0;
            dta.VG113_COD_PESSOA = result[i++].Value?.ToString();
            dta.VG113_SEQ_PESSOA_HIST = result[i++].Value?.ToString();
            dta.VG113_COD_CLASSIF_RISCO = result[i++].Value?.ToString();
            dta.VG113_NUM_SCORE_RISCO = result[i++].Value?.ToString();
            dta.VG113_DTA_CLASSIF_RISCO = result[i++].Value?.ToString();
            dta.VG113_IND_PEND_APROVACAO = result[i++].Value?.ToString();
            dta.VG113_IND_DECL_AUTOMATICO = result[i++].Value?.ToString();
            dta.VG113_IND_ATLZ_FAIXA_RISCO = result[i++].Value?.ToString();
            return dta;
        }

    }
}