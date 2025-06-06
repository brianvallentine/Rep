using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0852B
{
    public class R1150_00_VERIF_ULT_PARCELA_DB_SELECT_1_Query1 : QueryBasis<R1150_00_VERIF_ULT_PARCELA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PARCELA
            , OPCAO_PAGAMENTO
            , SIT_REGISTRO
            , DATA_VENCIMENTO
            INTO :COBHISVI-NUM-PARCELA
            , :COBHISVI-OPCAO-PAGAMENTO
            , :COBHISVI-SIT-REGISTRO
            , :COBHISVI-DATA-VENCIMENTO
            FROM SEGUROS.COBER_HIST_VIDAZUL
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND NUM_PARCELA = :PROPOVA-NUM-PARCELA
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PARCELA
											, OPCAO_PAGAMENTO
											, SIT_REGISTRO
											, DATA_VENCIMENTO
											FROM SEGUROS.COBER_HIST_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.PROPOVA_NUM_PARCELA}'
											WITH UR";

            return query;
        }
        public string COBHISVI_NUM_PARCELA { get; set; }
        public string COBHISVI_OPCAO_PAGAMENTO { get; set; }
        public string COBHISVI_SIT_REGISTRO { get; set; }
        public string COBHISVI_DATA_VENCIMENTO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_NUM_PARCELA { get; set; }

        public static R1150_00_VERIF_ULT_PARCELA_DB_SELECT_1_Query1 Execute(R1150_00_VERIF_ULT_PARCELA_DB_SELECT_1_Query1 r1150_00_VERIF_ULT_PARCELA_DB_SELECT_1_Query1)
        {
            var ths = r1150_00_VERIF_ULT_PARCELA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1150_00_VERIF_ULT_PARCELA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1150_00_VERIF_ULT_PARCELA_DB_SELECT_1_Query1();
            var i = 0;
            dta.COBHISVI_NUM_PARCELA = result[i++].Value?.ToString();
            dta.COBHISVI_OPCAO_PAGAMENTO = result[i++].Value?.ToString();
            dta.COBHISVI_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.COBHISVI_DATA_VENCIMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}