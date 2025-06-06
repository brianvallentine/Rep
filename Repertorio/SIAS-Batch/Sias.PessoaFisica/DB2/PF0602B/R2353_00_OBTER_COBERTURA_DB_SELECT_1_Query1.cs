using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0602B
{
    public class R2353_00_OBTER_COBERTURA_DB_SELECT_1_Query1 : QueryBasis<R2353_00_OBTER_COBERTURA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_OPCAO_PLANO ,
            COD_PRODUTO
            INTO :DCLBILHETE-COBERTURA.BILHECOB-COD-OPCAO-PLANO,
            :DCLBILHETE-COBERTURA.BILHECOB-COD-PRODUTO
            FROM SEGUROS.BILHETE_COBERTURA
            WHERE COD_EMPRESA =
            :DCLBILHETE-COBERTURA.BILHECOB-COD-EMPRESA
            AND MODALI_COBERTURA =
            :DCLBILHETE-COBERTURA.BILHECOB-MODALI-COBERTURA
            AND RAMO_COBERTURA =
            :DCLBILHETE-COBERTURA.BILHECOB-RAMO-COBERTURA
            AND PRM_TOTAL >= :WHOST-PREMIO-MIN
            AND PRM_TOTAL <= :WHOST-PREMIO-MAX
            AND DATA_INIVIGENCIA <=
            :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA
            AND DATA_TERVIGENCIA >=
            :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA
            AND DATA_TERVIGENCIA = '9997-12-31'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_OPCAO_PLANO 
							,
											COD_PRODUTO
											FROM SEGUROS.BILHETE_COBERTURA
											WHERE COD_EMPRESA =
											'{this.BILHECOB_COD_EMPRESA}'
											AND MODALI_COBERTURA =
											'{this.BILHECOB_MODALI_COBERTURA}'
											AND RAMO_COBERTURA =
											'{this.BILHECOB_RAMO_COBERTURA}'
											AND PRM_TOTAL >= '{this.WHOST_PREMIO_MIN}'
											AND PRM_TOTAL <= '{this.WHOST_PREMIO_MAX}'
											AND DATA_INIVIGENCIA <=
											'{this.DATA_PROPOSTA}'
											AND DATA_TERVIGENCIA >=
											'{this.DATA_PROPOSTA}'
											AND DATA_TERVIGENCIA = '9997-12-31'
											WITH UR";

            return query;
        }
        public string BILHECOB_COD_OPCAO_PLANO { get; set; }
        public string BILHECOB_COD_PRODUTO { get; set; }
        public string BILHECOB_MODALI_COBERTURA { get; set; }
        public string BILHECOB_RAMO_COBERTURA { get; set; }
        public string BILHECOB_COD_EMPRESA { get; set; }
        public string DATA_PROPOSTA { get; set; }
        public string WHOST_PREMIO_MIN { get; set; }
        public string WHOST_PREMIO_MAX { get; set; }

        public static R2353_00_OBTER_COBERTURA_DB_SELECT_1_Query1 Execute(R2353_00_OBTER_COBERTURA_DB_SELECT_1_Query1 r2353_00_OBTER_COBERTURA_DB_SELECT_1_Query1)
        {
            var ths = r2353_00_OBTER_COBERTURA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2353_00_OBTER_COBERTURA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2353_00_OBTER_COBERTURA_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILHECOB_COD_OPCAO_PLANO = result[i++].Value?.ToString();
            dta.BILHECOB_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}