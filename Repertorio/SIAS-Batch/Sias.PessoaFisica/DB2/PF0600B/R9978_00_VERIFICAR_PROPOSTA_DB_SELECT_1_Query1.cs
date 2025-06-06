using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0600B
{
    public class R9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1 : QueryBasis<R9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_IDENTIFICACAO ,
            NUM_SICOB ,
            DTQITBCO ,
            VAL_PAGO ,
            AGEPGTO ,
            SIT_PROPOSTA ,
            DATA_CREDITO
            INTO :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-IDENTIFICACAO,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-SICOB ,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DTQITBCO ,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-VAL-PAGO ,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-AGEPGTO ,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-SIT-PROPOSTA ,
            :DCLPROPOSTA-FIDELIZ.PROPOFID-DATA-CREDITO
            FROM SEGUROS.PROPOSTA_FIDELIZ
            WHERE NUM_PROPOSTA_SIVPF =
            :DCLPROPOSTA-FIDELIZ.PROPOFID-NUM-PROPOSTA-SIVPF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_IDENTIFICACAO 
							,
											NUM_SICOB 
							,
											DTQITBCO 
							,
											VAL_PAGO 
							,
											AGEPGTO 
							,
											SIT_PROPOSTA 
							,
											DATA_CREDITO
											FROM SEGUROS.PROPOSTA_FIDELIZ
											WHERE NUM_PROPOSTA_SIVPF =
											'{this.PROPOFID_NUM_PROPOSTA_SIVPF}'
											WITH UR";

            return query;
        }
        public string PROPOFID_NUM_IDENTIFICACAO { get; set; }
        public string PROPOFID_NUM_SICOB { get; set; }
        public string PROPOFID_DTQITBCO { get; set; }
        public string PROPOFID_VAL_PAGO { get; set; }
        public string PROPOFID_AGEPGTO { get; set; }
        public string PROPOFID_SIT_PROPOSTA { get; set; }
        public string PROPOFID_DATA_CREDITO { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static R9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1 Execute(R9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1 r9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1)
        {
            var ths = r9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R9978_00_VERIFICAR_PROPOSTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOFID_NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            dta.PROPOFID_NUM_SICOB = result[i++].Value?.ToString();
            dta.PROPOFID_DTQITBCO = result[i++].Value?.ToString();
            dta.PROPOFID_VAL_PAGO = result[i++].Value?.ToString();
            dta.PROPOFID_AGEPGTO = result[i++].Value?.ToString();
            dta.PROPOFID_SIT_PROPOSTA = result[i++].Value?.ToString();
            dta.PROPOFID_DATA_CREDITO = result[i++].Value?.ToString();
            return dta;
        }

    }
}