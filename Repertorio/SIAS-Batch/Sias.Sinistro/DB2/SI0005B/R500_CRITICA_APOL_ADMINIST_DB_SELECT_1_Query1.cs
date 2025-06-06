using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class R500_CRITICA_APOL_ADMINIST_DB_SELECT_1_Query1 : QueryBasis<R500_CRITICA_APOL_ADMINIST_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMP_SEG
            INTO :LOTISG01-IMP-SEG
            FROM SEGUROS.LOTIMPSEG01
            WHERE NUM_APOLICE = :LOTERI01-NUM-APOLICE
            AND RAMO_COBERTURA = :APOLICES-RAMO-EMISSOR
            AND MODALIDA_COBERTURA = :APOLICES-COD-MODALIDADE
            AND COD_COBERTURA = :LOTISG01-COD-COBERTURA
            AND COD_LOT_FENAL = :LOTERI01-COD-LOT-FENAL
            AND DTINIVIG <= :HOST-DATA-OCORRENCIA
            AND DTTERVIG >= :HOST-DATA-OCORRENCIA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMP_SEG
											FROM SEGUROS.LOTIMPSEG01
											WHERE NUM_APOLICE = '{this.LOTERI01_NUM_APOLICE}'
											AND RAMO_COBERTURA = '{this.APOLICES_RAMO_EMISSOR}'
											AND MODALIDA_COBERTURA = '{this.APOLICES_COD_MODALIDADE}'
											AND COD_COBERTURA = '{this.LOTISG01_COD_COBERTURA}'
											AND COD_LOT_FENAL = '{this.LOTERI01_COD_LOT_FENAL}'
											AND DTINIVIG <= '{this.HOST_DATA_OCORRENCIA}'
											AND DTTERVIG >= '{this.HOST_DATA_OCORRENCIA}'
											WITH UR";

            return query;
        }
        public string LOTISG01_IMP_SEG { get; set; }
        public string APOLICES_COD_MODALIDADE { get; set; }
        public string LOTISG01_COD_COBERTURA { get; set; }
        public string LOTERI01_COD_LOT_FENAL { get; set; }
        public string APOLICES_RAMO_EMISSOR { get; set; }
        public string LOTERI01_NUM_APOLICE { get; set; }
        public string HOST_DATA_OCORRENCIA { get; set; }

        public static R500_CRITICA_APOL_ADMINIST_DB_SELECT_1_Query1 Execute(R500_CRITICA_APOL_ADMINIST_DB_SELECT_1_Query1 r500_CRITICA_APOL_ADMINIST_DB_SELECT_1_Query1)
        {
            var ths = r500_CRITICA_APOL_ADMINIST_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R500_CRITICA_APOL_ADMINIST_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R500_CRITICA_APOL_ADMINIST_DB_SELECT_1_Query1();
            var i = 0;
            dta.LOTISG01_IMP_SEG = result[i++].Value?.ToString();
            return dta;
        }

    }
}