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
    public class R1800_00_SELECT_FIDRLIZ_DB_SELECT_1_Query1 : QueryBasis<R1800_00_SELECT_FIDRLIZ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA_SIVPF,
            NUM_IDENTIFICACAO,
            COD_EMPRESA_SIVPF,
            COD_PRODUTO_SIVPF
            INTO :PROPOFID-NUM-PROPOSTA-SIVPF,
            :PROPOFID-NUM-IDENTIFICACAO,
            :PROPOFID-COD-EMPRESA-SIVPF,
            :PROPOFID-COD-PRODUTO-SIVPF
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF = :PROPOVA-NUM-CERTIFICADO
            AND SIT_PROPOSTA <> 'CAN'
            UNION
            SELECT NUM_SICOB,
            NUM_IDENTIFICACAO,
            COD_EMPRESA_SIVPF,
            COD_PRODUTO_SIVPF
            INTO :PROPOFID-NUM-PROPOSTA-SIVPF,
            :PROPOFID-NUM-IDENTIFICACAO,
            :PROPOFID-COD-EMPRESA-SIVPF,
            :PROPOFID-COD-PRODUTO-SIVPF
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_SICOB = :PROPOVA-NUM-CERTIFICADO
            AND SIT_PROPOSTA <> 'CAN'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA_SIVPF
							,
											NUM_IDENTIFICACAO
							,
											COD_EMPRESA_SIVPF
							,
											COD_PRODUTO_SIVPF
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND SIT_PROPOSTA <> 'CAN'
											UNION
											SELECT NUM_SICOB
							,
											NUM_IDENTIFICACAO
							,
											COD_EMPRESA_SIVPF
							,
											COD_PRODUTO_SIVPF
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_SICOB = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND SIT_PROPOSTA <> 'CAN'";

            return query;
        }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }
        public string PROPOFID_COD_EMPRESA_SIVPF { get; set; }
        public string PROPOFID_COD_PRODUTO_SIVPF { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R1800_00_SELECT_FIDRLIZ_DB_SELECT_1_Query1 Execute(R1800_00_SELECT_FIDRLIZ_DB_SELECT_1_Query1 r1800_00_SELECT_FIDRLIZ_DB_SELECT_1_Query1)
        {
            var ths = r1800_00_SELECT_FIDRLIZ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1800_00_SELECT_FIDRLIZ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1800_00_SELECT_FIDRLIZ_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            dta.PROPOFID_COD_EMPRESA_SIVPF = result[i++].Value?.ToString();
            dta.PROPOFID_COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}