using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE2640B
{
    public class DB110_ACESSA_TERMO_ADESAO_DB_SELECT_1_Query1 : QueryBasis<DB110_ACESSA_TERMO_ADESAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_TERMO
            , NUM_MATRICULA_VEN
            , COD_AGENCIA_VEN
            , OPERACAO_CONTA_VEN
            , NUM_CONTA_VEN
            , DIG_CONTA_VEN
            , COD_PLANO_VGAPC
            INTO :TERMOADE-NUM-TERMO
            ,:TERMOADE-NUM-MATRICULA-VEN
            ,:TERMOADE-COD-AGENCIA-VEN
            ,:TERMOADE-OPERACAO-CONTA-VEN
            ,:TERMOADE-NUM-CONTA-VEN
            ,:TERMOADE-DIG-CONTA-VEN
            ,:TERMOADE-COD-PLANO-VGAPC
            FROM SEGUROS.TERMO_ADESAO
            WHERE NUM_APOLICE = :VGSOLFAT-NUM-APOLICE
            AND COD_SUBGRUPO = :VGSOLFAT-COD-SUBGRUPO
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_TERMO
											, NUM_MATRICULA_VEN
											, COD_AGENCIA_VEN
											, OPERACAO_CONTA_VEN
											, NUM_CONTA_VEN
											, DIG_CONTA_VEN
											, COD_PLANO_VGAPC
											FROM SEGUROS.TERMO_ADESAO
											WHERE NUM_APOLICE = '{this.VGSOLFAT_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.VGSOLFAT_COD_SUBGRUPO}'
											WITH UR";

            return query;
        }
        public string TERMOADE_NUM_TERMO { get; set; }
        public string TERMOADE_NUM_MATRICULA_VEN { get; set; }
        public string TERMOADE_COD_AGENCIA_VEN { get; set; }
        public string TERMOADE_OPERACAO_CONTA_VEN { get; set; }
        public string TERMOADE_NUM_CONTA_VEN { get; set; }
        public string TERMOADE_DIG_CONTA_VEN { get; set; }
        public string TERMOADE_COD_PLANO_VGAPC { get; set; }
        public string VGSOLFAT_COD_SUBGRUPO { get; set; }
        public string VGSOLFAT_NUM_APOLICE { get; set; }

        public static DB110_ACESSA_TERMO_ADESAO_DB_SELECT_1_Query1 Execute(DB110_ACESSA_TERMO_ADESAO_DB_SELECT_1_Query1 dB110_ACESSA_TERMO_ADESAO_DB_SELECT_1_Query1)
        {
            var ths = dB110_ACESSA_TERMO_ADESAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override DB110_ACESSA_TERMO_ADESAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new DB110_ACESSA_TERMO_ADESAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.TERMOADE_NUM_TERMO = result[i++].Value?.ToString();
            dta.TERMOADE_NUM_MATRICULA_VEN = result[i++].Value?.ToString();
            dta.TERMOADE_COD_AGENCIA_VEN = result[i++].Value?.ToString();
            dta.TERMOADE_OPERACAO_CONTA_VEN = result[i++].Value?.ToString();
            dta.TERMOADE_NUM_CONTA_VEN = result[i++].Value?.ToString();
            dta.TERMOADE_DIG_CONTA_VEN = result[i++].Value?.ToString();
            dta.TERMOADE_COD_PLANO_VGAPC = result[i++].Value?.ToString();
            return dta;
        }

    }
}