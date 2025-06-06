using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0648B
{
    public class R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 : QueryBasis<R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PRODUTO_SIVPF,
            SIT_PROPOSTA,
            NUM_SICOB,
            DATA_PROPOSTA,
            AGECOBR,
            NOME_CONVENENTE,
            NRMATRCON,
            CGC_CONVENENTE,
            PERC_DESCONTO,
            COD_PLANO,
            ORIGEM_PROPOSTA
            INTO :DCLPROPOSTA-FIDELIZ.COD-PRODUTO-SIVPF,
            :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA,
            :DCLPROPOSTA-FIDELIZ.NUM-SICOB,
            :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA,
            :DCLPROPOSTA-FIDELIZ.AGECOBR,
            :DCLPROPOSTA-FIDELIZ.NOME-CONVENENTE,
            :DCLPROPOSTA-FIDELIZ.NRMATRCON,
            :DCLPROPOSTA-FIDELIZ.CGC-CONVENENTE,
            :DCLPROPOSTA-FIDELIZ.PERC-DESCONTO,
            :DCLPROPOSTA-FIDELIZ.COD-PLANO,
            :DCLPROPOSTA-FIDELIZ.ORIGEM-PROPOSTA
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF =
            :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_PRODUTO_SIVPF
							,
											SIT_PROPOSTA
							,
											NUM_SICOB
							,
											DATA_PROPOSTA
							,
											AGECOBR
							,
											NOME_CONVENENTE
							,
											NRMATRCON
							,
											CGC_CONVENENTE
							,
											PERC_DESCONTO
							,
											COD_PLANO
							,
											ORIGEM_PROPOSTA
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF =
											'{this.NUM_PROPOSTA_SIVPF}'
											WITH UR";

            return query;
        }
        public string COD_PRODUTO_SIVPF { get; set; }
        public string SIT_PROPOSTA { get; set; }
        public string NUM_SICOB { get; set; }
        public string DATA_PROPOSTA { get; set; }
        public string AGECOBR { get; set; }
        public string NOME_CONVENENTE { get; set; }
        public string NRMATRCON { get; set; }
        public string CGC_CONVENENTE { get; set; }
        public string PERC_DESCONTO { get; set; }
        public string COD_PLANO { get; set; }
        public string ORIGEM_PROPOSTA { get; set; }
        public string NUM_PROPOSTA_SIVPF { get; set; }

        public static R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 Execute(R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 r0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1)
        {
            var ths = r0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1();
            var i = 0;
            dta.COD_PRODUTO_SIVPF = result[i++].Value?.ToString();
            dta.SIT_PROPOSTA = result[i++].Value?.ToString();
            dta.NUM_SICOB = result[i++].Value?.ToString();
            dta.DATA_PROPOSTA = result[i++].Value?.ToString();
            dta.AGECOBR = result[i++].Value?.ToString();
            dta.NOME_CONVENENTE = result[i++].Value?.ToString();
            dta.NRMATRCON = result[i++].Value?.ToString();
            dta.CGC_CONVENENTE = result[i++].Value?.ToString();
            dta.PERC_DESCONTO = result[i++].Value?.ToString();
            dta.COD_PLANO = result[i++].Value?.ToString();
            dta.ORIGEM_PROPOSTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}