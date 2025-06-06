using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF2002B
{
    public class R3800_INCLUI_CONVERSAO_DB_INSERT_1_Insert1 : QueryBasis<R3800_INCLUI_CONVERSAO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.CONVERSAO_SICOB
            ( NUM_PROPOSTA_SIVPF
            , NUM_SICOB
            , COD_EMPRESA_SIVPF
            , COD_PRODUTO_SIVPF
            , AGEPGTO
            , DATA_OPERACAO
            , DATA_QUITACAO
            , VAL_RCAP
            , COD_USUARIO
            , TIMESTAMP )
            VALUES (:V0FILT-NUMSIVPF ,
            :V0FILT-NUMSICOB ,
            :V0FILT-CODEMP ,
            :V0FILT-CODSIVPF ,
            :V0FILT-AGECOBR ,
            :V0FILT-DTMOVTO ,
            :V0FILT-DTQITBCO ,
            :V0FILT-VLRCAP ,
            :V0FILT-CODUSU ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CONVERSAO_SICOB ( NUM_PROPOSTA_SIVPF , NUM_SICOB , COD_EMPRESA_SIVPF , COD_PRODUTO_SIVPF , AGEPGTO , DATA_OPERACAO , DATA_QUITACAO , VAL_RCAP , COD_USUARIO , TIMESTAMP ) VALUES ({FieldThreatment(this.V0FILT_NUMSIVPF)} , {FieldThreatment(this.V0FILT_NUMSICOB)} , {FieldThreatment(this.V0FILT_CODEMP)} , {FieldThreatment(this.V0FILT_CODSIVPF)} , {FieldThreatment(this.V0FILT_AGECOBR)} , {FieldThreatment(this.V0FILT_DTMOVTO)} , {FieldThreatment(this.V0FILT_DTQITBCO)} , {FieldThreatment(this.V0FILT_VLRCAP)} , {FieldThreatment(this.V0FILT_CODUSU)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string V0FILT_NUMSIVPF { get; set; }
        public string V0FILT_NUMSICOB { get; set; }
        public string V0FILT_CODEMP { get; set; }
        public string V0FILT_CODSIVPF { get; set; }
        public string V0FILT_AGECOBR { get; set; }
        public string V0FILT_DTMOVTO { get; set; }
        public string V0FILT_DTQITBCO { get; set; }
        public string V0FILT_VLRCAP { get; set; }
        public string V0FILT_CODUSU { get; set; }

        public static void Execute(R3800_INCLUI_CONVERSAO_DB_INSERT_1_Insert1 r3800_INCLUI_CONVERSAO_DB_INSERT_1_Insert1)
        {
            var ths = r3800_INCLUI_CONVERSAO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3800_INCLUI_CONVERSAO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}