using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0864B
{
    public class R100_BUSCAR_INFO_LOTERICO01_DB_SELECT_1_Query1 : QueryBasis<R100_BUSCAR_INFO_LOTERICO01_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_FANTASIA, NUM_ENCEF, NUM_PVCEF, ENDERECO,
            COMPL_ENDERECO,
            BAIRRO, CEP, CIDADE,
            SIGLA_UF, DDD, NUM_FONE
            INTO :LOTERI01-NOME-FANTASIA,
            :LOTERI01-NUM-ENCEF,
            :LOTERI01-NUM-PVCEF,
            :LOTERI01-ENDERECO,
            :LOTERI01-COMPL-ENDERECO,
            :LOTERI01-BAIRRO,
            :LOTERI01-CEP,
            :LOTERI01-CIDADE,
            :LOTERI01-SIGLA-UF,
            :LOTERI01-DDD,
            :LOTERI01-NUM-FONE
            FROM SEGUROS.LOTERICO01
            WHERE COD_LOT_FENAL = :SINILT01-COD-LOT-FENAL
            AND NUM_APOLICE = :SINILT01-NUM-APOLICE
            AND DTINIVIG = :SINILT01-DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_FANTASIA
							, NUM_ENCEF
							, NUM_PVCEF
							, ENDERECO
							,
											COMPL_ENDERECO
							,
											BAIRRO
							, CEP
							, CIDADE
							,
											SIGLA_UF
							, DDD
							, NUM_FONE
											FROM SEGUROS.LOTERICO01
											WHERE COD_LOT_FENAL = '{this.SINILT01_COD_LOT_FENAL}'
											AND NUM_APOLICE = '{this.SINILT01_NUM_APOLICE}'
											AND DTINIVIG = '{this.SINILT01_DTINIVIG}'";

            return query;
        }
        public string LOTERI01_NOME_FANTASIA { get; set; }
        public string LOTERI01_NUM_ENCEF { get; set; }
        public string LOTERI01_NUM_PVCEF { get; set; }
        public string LOTERI01_ENDERECO { get; set; }
        public string LOTERI01_COMPL_ENDERECO { get; set; }
        public string LOTERI01_BAIRRO { get; set; }
        public string LOTERI01_CEP { get; set; }
        public string LOTERI01_CIDADE { get; set; }
        public string LOTERI01_SIGLA_UF { get; set; }
        public string LOTERI01_DDD { get; set; }
        public string LOTERI01_NUM_FONE { get; set; }
        public string SINILT01_COD_LOT_FENAL { get; set; }
        public string SINILT01_NUM_APOLICE { get; set; }
        public string SINILT01_DTINIVIG { get; set; }

        public static R100_BUSCAR_INFO_LOTERICO01_DB_SELECT_1_Query1 Execute(R100_BUSCAR_INFO_LOTERICO01_DB_SELECT_1_Query1 r100_BUSCAR_INFO_LOTERICO01_DB_SELECT_1_Query1)
        {
            var ths = r100_BUSCAR_INFO_LOTERICO01_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R100_BUSCAR_INFO_LOTERICO01_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R100_BUSCAR_INFO_LOTERICO01_DB_SELECT_1_Query1();
            var i = 0;
            dta.LOTERI01_NOME_FANTASIA = result[i++].Value?.ToString();
            dta.LOTERI01_NUM_ENCEF = result[i++].Value?.ToString();
            dta.LOTERI01_NUM_PVCEF = result[i++].Value?.ToString();
            dta.LOTERI01_ENDERECO = result[i++].Value?.ToString();
            dta.LOTERI01_COMPL_ENDERECO = result[i++].Value?.ToString();
            dta.LOTERI01_BAIRRO = result[i++].Value?.ToString();
            dta.LOTERI01_CEP = result[i++].Value?.ToString();
            dta.LOTERI01_CIDADE = result[i++].Value?.ToString();
            dta.LOTERI01_SIGLA_UF = result[i++].Value?.ToString();
            dta.LOTERI01_DDD = result[i++].Value?.ToString();
            dta.LOTERI01_NUM_FONE = result[i++].Value?.ToString();
            return dta;
        }

    }
}