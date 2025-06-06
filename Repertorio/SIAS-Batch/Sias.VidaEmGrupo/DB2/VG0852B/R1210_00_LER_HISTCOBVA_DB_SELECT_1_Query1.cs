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
    public class R1210_00_LER_HISTCOBVA_DB_SELECT_1_Query1 : QueryBasis<R1210_00_LER_HISTCOBVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_REGISTRO,
            DATA_VENCIMENTO,
            NUM_TITULO
            ,OPCAO_PAGAMENTO
            INTO :COBHISVI-SIT-REGISTRO,
            :COBHISVI-DATA-VENCIMENTO,
            :COBHISVI-NUM-TITULO
            ,:COBHISVI-OPCAO-PAGAMENTO
            FROM SEGUROS.COBER_HIST_VIDAZUL
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND NUM_PARCELA = :PROPOVA-NUM-PARCELA
            AND SIT_REGISTRO <> '2'
            AND NUM_TITULO =
            (SELECT MAX(A.NUM_TITULO)
            FROM SEGUROS.COBER_HIST_VIDAZUL A
            WHERE A.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND A.NUM_PARCELA = :PROPOVA-NUM-PARCELA
            AND A.SIT_REGISTRO <> '2' )
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO
							,
											DATA_VENCIMENTO
							,
											NUM_TITULO
											,OPCAO_PAGAMENTO
											FROM SEGUROS.COBER_HIST_VIDAZUL
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND NUM_PARCELA = '{this.PROPOVA_NUM_PARCELA}'
											AND SIT_REGISTRO <> '2'
											AND NUM_TITULO =
											(SELECT MAX(A.NUM_TITULO)
											FROM SEGUROS.COBER_HIST_VIDAZUL A
											WHERE A.NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND A.NUM_PARCELA = '{this.PROPOVA_NUM_PARCELA}'
											AND A.SIT_REGISTRO <> '2' )
											WITH UR";

            return query;
        }
        public string COBHISVI_SIT_REGISTRO { get; set; }
        public string COBHISVI_DATA_VENCIMENTO { get; set; }
        public string COBHISVI_NUM_TITULO { get; set; }
        public string COBHISVI_OPCAO_PAGAMENTO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_NUM_PARCELA { get; set; }

        public static R1210_00_LER_HISTCOBVA_DB_SELECT_1_Query1 Execute(R1210_00_LER_HISTCOBVA_DB_SELECT_1_Query1 r1210_00_LER_HISTCOBVA_DB_SELECT_1_Query1)
        {
            var ths = r1210_00_LER_HISTCOBVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1210_00_LER_HISTCOBVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1210_00_LER_HISTCOBVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.COBHISVI_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.COBHISVI_DATA_VENCIMENTO = result[i++].Value?.ToString();
            dta.COBHISVI_NUM_TITULO = result[i++].Value?.ToString();
            dta.COBHISVI_OPCAO_PAGAMENTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}