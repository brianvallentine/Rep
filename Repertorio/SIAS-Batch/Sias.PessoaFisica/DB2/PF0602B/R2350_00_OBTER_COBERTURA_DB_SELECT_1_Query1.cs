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
    public class R2350_00_OBTER_COBERTURA_DB_SELECT_1_Query1 : QueryBasis<R2350_00_OBTER_COBERTURA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_OPCAO_PLANO
            INTO :DCLBILHETE-COBERTURA.BILHECOB-COD-OPCAO-PLANO
            FROM SEGUROS.BILHETE_COBERTURA
            WHERE COD_EMPRESA =
            :DCLBILHETE-COBERTURA.BILHECOB-COD-EMPRESA
            AND MODALI_COBERTURA =
            :DCLBILHETE-COBERTURA.BILHECOB-MODALI-COBERTURA
            AND RAMO_COBERTURA =
            :DCLBILHETE-COBERTURA.BILHECOB-RAMO-COBERTURA
            AND PRM_TOTAL =
            :DCLBILHETE-COBERTURA.BILHECOB-PRM-TOTAL
            AND DATA_INIVIGENCIA <=
            :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA
            AND DATA_TERVIGENCIA >=
            :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_OPCAO_PLANO
											FROM SEGUROS.BILHETE_COBERTURA
											WHERE COD_EMPRESA =
											'{this.BILHECOB_COD_EMPRESA}'
											AND MODALI_COBERTURA =
											'{this.BILHECOB_MODALI_COBERTURA}'
											AND RAMO_COBERTURA =
											'{this.BILHECOB_RAMO_COBERTURA}'
											AND PRM_TOTAL =
											'{this.BILHECOB_PRM_TOTAL}'
											AND DATA_INIVIGENCIA <=
											'{this.DATA_PROPOSTA}'
											AND DATA_TERVIGENCIA >=
											'{this.DATA_PROPOSTA}'
											WITH UR";

            return query;
        }
        public string BILHECOB_COD_OPCAO_PLANO { get; set; }
        public string BILHECOB_MODALI_COBERTURA { get; set; }
        public string BILHECOB_RAMO_COBERTURA { get; set; }
        public string BILHECOB_COD_EMPRESA { get; set; }
        public string BILHECOB_PRM_TOTAL { get; set; }
        public string DATA_PROPOSTA { get; set; }

        public static R2350_00_OBTER_COBERTURA_DB_SELECT_1_Query1 Execute(R2350_00_OBTER_COBERTURA_DB_SELECT_1_Query1 r2350_00_OBTER_COBERTURA_DB_SELECT_1_Query1)
        {
            var ths = r2350_00_OBTER_COBERTURA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2350_00_OBTER_COBERTURA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2350_00_OBTER_COBERTURA_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILHECOB_COD_OPCAO_PLANO = result[i++].Value?.ToString();
            return dta;
        }

    }
}