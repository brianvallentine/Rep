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
    public class R2690_INCLUI_V0MOVICOB_DB_INSERT_1_Insert1 : QueryBasis<R2690_INCLUI_V0MOVICOB_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0MOVICOB
            ( COD_EMPRESA,
            CODMOV,
            BANCO,
            AGENCIA,
            NRAVISO,
            NUMFITA,
            DTMOVTO,
            DTQITBCO,
            NRTIT,
            NUM_APOLICE,
            NRENDOS,
            NRPARCEL,
            VALTIT,
            VLIOCC,
            VALCDT,
            SITUACAO,
            TIMESTAMP,
            NOME,
            TIPO_MOVIMENTO,
            NUM_NOSSO_TITULO)
            VALUES (:V0MCOB-CODEMP ,
            :V0MCOB-CODMOV ,
            :V0MCOB-BANCO ,
            :V0MCOB-AGENCIA ,
            :V0MCOB-NRAVISO ,
            :V0MCOB-NUMFITA ,
            :V0MCOB-DTMOVTO ,
            :V0MCOB-DTQITBCO ,
            :V0MCOB-NRTIT ,
            :V0MCOB-NUMAPOL ,
            :V0MCOB-NRENDOS ,
            :V0MCOB-NRPARCEL ,
            :V0MCOB-VALTIT ,
            :V0MCOB-VLIOCC ,
            :V0MCOB-VALCDT ,
            :V0MCOB-SITUACAO ,
            CURRENT TIMESTAMP ,
            :V0MCOB-NOME ,
            :V0MCOB-TIPOMOV ,
            :V0MCOB-NUM-NOSSO-TITULO)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0MOVICOB ( COD_EMPRESA, CODMOV, BANCO, AGENCIA, NRAVISO, NUMFITA, DTMOVTO, DTQITBCO, NRTIT, NUM_APOLICE, NRENDOS, NRPARCEL, VALTIT, VLIOCC, VALCDT, SITUACAO, TIMESTAMP, NOME, TIPO_MOVIMENTO, NUM_NOSSO_TITULO) VALUES ({FieldThreatment(this.V0MCOB_CODEMP)} , {FieldThreatment(this.V0MCOB_CODMOV)} , {FieldThreatment(this.V0MCOB_BANCO)} , {FieldThreatment(this.V0MCOB_AGENCIA)} , {FieldThreatment(this.V0MCOB_NRAVISO)} , {FieldThreatment(this.V0MCOB_NUMFITA)} , {FieldThreatment(this.V0MCOB_DTMOVTO)} , {FieldThreatment(this.V0MCOB_DTQITBCO)} , {FieldThreatment(this.V0MCOB_NRTIT)} , {FieldThreatment(this.V0MCOB_NUMAPOL)} , {FieldThreatment(this.V0MCOB_NRENDOS)} , {FieldThreatment(this.V0MCOB_NRPARCEL)} , {FieldThreatment(this.V0MCOB_VALTIT)} , {FieldThreatment(this.V0MCOB_VLIOCC)} , {FieldThreatment(this.V0MCOB_VALCDT)} , {FieldThreatment(this.V0MCOB_SITUACAO)} , CURRENT TIMESTAMP , {FieldThreatment(this.V0MCOB_NOME)} , {FieldThreatment(this.V0MCOB_TIPOMOV)} , {FieldThreatment(this.V0MCOB_NUM_NOSSO_TITULO)})";

            return query;
        }
        public string V0MCOB_CODEMP { get; set; }
        public string V0MCOB_CODMOV { get; set; }
        public string V0MCOB_BANCO { get; set; }
        public string V0MCOB_AGENCIA { get; set; }
        public string V0MCOB_NRAVISO { get; set; }
        public string V0MCOB_NUMFITA { get; set; }
        public string V0MCOB_DTMOVTO { get; set; }
        public string V0MCOB_DTQITBCO { get; set; }
        public string V0MCOB_NRTIT { get; set; }
        public string V0MCOB_NUMAPOL { get; set; }
        public string V0MCOB_NRENDOS { get; set; }
        public string V0MCOB_NRPARCEL { get; set; }
        public string V0MCOB_VALTIT { get; set; }
        public string V0MCOB_VLIOCC { get; set; }
        public string V0MCOB_VALCDT { get; set; }
        public string V0MCOB_SITUACAO { get; set; }
        public string V0MCOB_NOME { get; set; }
        public string V0MCOB_TIPOMOV { get; set; }
        public string V0MCOB_NUM_NOSSO_TITULO { get; set; }

        public static void Execute(R2690_INCLUI_V0MOVICOB_DB_INSERT_1_Insert1 r2690_INCLUI_V0MOVICOB_DB_INSERT_1_Insert1)
        {
            var ths = r2690_INCLUI_V0MOVICOB_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2690_INCLUI_V0MOVICOB_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}