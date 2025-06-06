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
    public class R3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1_Insert1 : QueryBasis<R3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.VG_COMPL_SICAQWEB
            ( NUM_CERTIFICADO
            , COD_OPERADOR
            , NUM_CORRESP_CX_AQUI
            , IND_TP_CORRESP_SICAQ
            , DTA_CONTRATACAO
            , HRA_CONTRATACAO
            , NUM_PROPOSTA_SICAQ
            , IND_ORIGEM_PROPOSTA
            , NOM_PROGRAMA
            , DTH_CADASTRAMENTO )
            VALUES ( :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF
            ,:VG084-COD-OPERADOR
            ,:VG084-NUM-CORRESP-CX-AQUI
            ,:VG084-IND-TP-CORRESP-SICAQ
            ,:VG084-DTA-CONTRATACAO
            ,:VG084-HRA-CONTRATACAO
            ,:VG084-NUM-PROPOSTA-SICAQ
            ,:VG084-IND-ORIGEM-PROPOSTA
            ,:VG084-NOM-PROGRAMA
            , CURRENT TIMESTAMP )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.VG_COMPL_SICAQWEB ( NUM_CERTIFICADO , COD_OPERADOR , NUM_CORRESP_CX_AQUI , IND_TP_CORRESP_SICAQ , DTA_CONTRATACAO , HRA_CONTRATACAO , NUM_PROPOSTA_SICAQ , IND_ORIGEM_PROPOSTA , NOM_PROGRAMA , DTH_CADASTRAMENTO ) VALUES ( {FieldThreatment(this.NUM_PROPOSTA_SIVPF)} ,{FieldThreatment(this.VG084_COD_OPERADOR)} ,{FieldThreatment(this.VG084_NUM_CORRESP_CX_AQUI)} ,{FieldThreatment(this.VG084_IND_TP_CORRESP_SICAQ)} ,{FieldThreatment(this.VG084_DTA_CONTRATACAO)} ,{FieldThreatment(this.VG084_HRA_CONTRATACAO)} ,{FieldThreatment(this.VG084_NUM_PROPOSTA_SICAQ)} ,{FieldThreatment(this.VG084_IND_ORIGEM_PROPOSTA)} ,{FieldThreatment(this.VG084_NOM_PROGRAMA)} , CURRENT TIMESTAMP )";

            return query;
        }
        public string NUM_PROPOSTA_SIVPF { get; set; }
        public string VG084_COD_OPERADOR { get; set; }
        public string VG084_NUM_CORRESP_CX_AQUI { get; set; }
        public string VG084_IND_TP_CORRESP_SICAQ { get; set; }
        public string VG084_DTA_CONTRATACAO { get; set; }
        public string VG084_HRA_CONTRATACAO { get; set; }
        public string VG084_NUM_PROPOSTA_SICAQ { get; set; }
        public string VG084_IND_ORIGEM_PROPOSTA { get; set; }
        public string VG084_NOM_PROGRAMA { get; set; }

        public static void Execute(R3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1_Insert1 r3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1_Insert1)
        {
            var ths = r3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3010_00_INSERT_COMPL_SICAQWEB_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}