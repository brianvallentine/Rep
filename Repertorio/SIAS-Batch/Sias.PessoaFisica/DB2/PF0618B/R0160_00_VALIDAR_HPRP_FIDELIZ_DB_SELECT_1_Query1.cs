using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0618B
{
    public class R0160_00_VALIDAR_HPRP_FIDELIZ_DB_SELECT_1_Query1 : QueryBasis<R0160_00_VALIDAR_HPRP_FIDELIZ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_MOTIVO_SIVPF,
            NSAS_SIVPF,
            NUM_IDENTIFICACAO,
            DATA_SITUACAO,
            SIT_PROPOSTA
            INTO :PROPFIDH-SIT-MOTIVO-SIVPF,
            :PROPFIDH-NSAS-SIVPF,
            :PROPFIDH-NUM-IDENTIFICACAO,
            :PROPFIDH-DATA-SITUACAO,
            :PROPFIDH-SIT-PROPOSTA
            FROM SEGUROS.HIST_PROP_FIDELIZ
            WHERE NUM_IDENTIFICACAO =
            :PROPOFID-NUM-IDENTIFICACAO
            AND DATA_SITUACAO =
            :MOVIMVGA-DATA-OPERACAO
            AND SIT_PROPOSTA =
            :PROPFIDH-SIT-PROPOSTA
            AND SIT_MOTIVO_SIVPF =
            :PROPFIDH-SIT-MOTIVO-SIVPF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_MOTIVO_SIVPF
							,
											NSAS_SIVPF
							,
											NUM_IDENTIFICACAO
							,
											DATA_SITUACAO
							,
											SIT_PROPOSTA
											FROM SEGUROS.HIST_PROP_FIDELIZ
											WHERE NUM_IDENTIFICACAO =
											'{this.PROPOFID_NUM_IDENTIFICACAO}'
											AND DATA_SITUACAO =
											'{this.MOVIMVGA_DATA_OPERACAO}'
											AND SIT_PROPOSTA =
											'{this.PROPFIDH_SIT_PROPOSTA}'
											AND SIT_MOTIVO_SIVPF =
											'{this.PROPFIDH_SIT_MOTIVO_SIVPF}'
											WITH UR";

            return query;
        }
        public string PROPFIDH_SIT_MOTIVO_SIVPF { get; set; }
        public string PROPFIDH_NSAS_SIVPF { get; set; }
        public string PROPFIDH_NUM_IDENTIFICACAO { get; set; }
        public string PROPFIDH_DATA_SITUACAO { get; set; }
        public string PROPFIDH_SIT_PROPOSTA { get; set; }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }
        public string MOVIMVGA_DATA_OPERACAO { get; set; }

        public static R0160_00_VALIDAR_HPRP_FIDELIZ_DB_SELECT_1_Query1 Execute(R0160_00_VALIDAR_HPRP_FIDELIZ_DB_SELECT_1_Query1 r0160_00_VALIDAR_HPRP_FIDELIZ_DB_SELECT_1_Query1)
        {
            var ths = r0160_00_VALIDAR_HPRP_FIDELIZ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0160_00_VALIDAR_HPRP_FIDELIZ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0160_00_VALIDAR_HPRP_FIDELIZ_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPFIDH_SIT_MOTIVO_SIVPF = result[i++].Value?.ToString();
            dta.PROPFIDH_NSAS_SIVPF = result[i++].Value?.ToString();
            dta.PROPFIDH_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            dta.PROPFIDH_DATA_SITUACAO = result[i++].Value?.ToString();
            dta.PROPFIDH_SIT_PROPOSTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}