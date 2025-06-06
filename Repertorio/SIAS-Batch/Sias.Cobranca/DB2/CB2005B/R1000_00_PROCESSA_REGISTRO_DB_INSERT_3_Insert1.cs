using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB2005B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_INSERT_3_Insert1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_INSERT_3_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0APOLCOB
            (COD_EMPRESA ,
            FONTE ,
            NUM_APOLICE ,
            NRENDOS ,
            CODPRODU ,
            NUM_MATRICULA ,
            TIPO_COBRANCA ,
            AGECOBR ,
            COD_AGENCIA ,
            OPERACAO_CONTA ,
            NUM_CONTA ,
            DIG_CONTA ,
            COD_AGENCIA_DEB ,
            OPER_CONTA_DEB ,
            NUM_CONTA_DEB ,
            DIG_CONTA_DEB ,
            NUM_CARTAO ,
            DIA_DEBITO ,
            NRCERTIF_AUTO ,
            TIMESTAMP ,
            MARGEM_COMERCIAL)
            VALUES (:V0APCB-COD-EMPRESA ,
            :V0APCB-FONTE ,
            :V0APCB-NUM-APOL ,
            :V0APCB-NRENDOS ,
            :V0APCB-CODPRODU ,
            :V0APCB-NUM-MATR ,
            :V0APCB-TIPOCOB ,
            :V0APCB-AGECOBR ,
            :V0APCB-AGENCIA ,
            :V0APCB-OPE-CONTA ,
            :V0APCB-NUM-CONTA ,
            :V0APCB-DIG-CONTA ,
            :V0APCB-AGENCIA-DEB:VIND-AGENCIA ,
            :V0APCB-OPERACAO-DEB:VIND-OPERACAO ,
            :V0APCB-NUMCTA-DEB:VIND-NUMCONTA ,
            :V0APCB-DIGCTA-DEB:VIND-DIGCONTA ,
            :V0APCB-NUM-CARTAO:VIND-NUMCARTAO ,
            :V0APCB-DIA-DEBITO:VIND-DIADEBITO ,
            :V0APCB-NRCERTIF:VIND-NRCERTIF ,
            CURRENT TIMESTAMP ,
            :V0APCB-MARGEM:VIND-MARGEM)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0APOLCOB (COD_EMPRESA , FONTE , NUM_APOLICE , NRENDOS , CODPRODU , NUM_MATRICULA , TIPO_COBRANCA , AGECOBR , COD_AGENCIA , OPERACAO_CONTA , NUM_CONTA , DIG_CONTA , COD_AGENCIA_DEB , OPER_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , NUM_CARTAO , DIA_DEBITO , NRCERTIF_AUTO , TIMESTAMP , MARGEM_COMERCIAL) VALUES ({FieldThreatment(this.V0APCB_COD_EMPRESA)} , {FieldThreatment(this.V0APCB_FONTE)} , {FieldThreatment(this.V0APCB_NUM_APOL)} , {FieldThreatment(this.V0APCB_NRENDOS)} , {FieldThreatment(this.V0APCB_CODPRODU)} , {FieldThreatment(this.V0APCB_NUM_MATR)} , {FieldThreatment(this.V0APCB_TIPOCOB)} , {FieldThreatment(this.V0APCB_AGECOBR)} , {FieldThreatment(this.V0APCB_AGENCIA)} , {FieldThreatment(this.V0APCB_OPE_CONTA)} , {FieldThreatment(this.V0APCB_NUM_CONTA)} , {FieldThreatment(this.V0APCB_DIG_CONTA)} ,  {FieldThreatment((this.VIND_AGENCIA?.ToInt() == -1 ? null : this.V0APCB_AGENCIA_DEB))} ,  {FieldThreatment((this.VIND_OPERACAO?.ToInt() == -1 ? null : this.V0APCB_OPERACAO_DEB))} ,  {FieldThreatment((this.VIND_NUMCONTA?.ToInt() == -1 ? null : this.V0APCB_NUMCTA_DEB))} ,  {FieldThreatment((this.VIND_DIGCONTA?.ToInt() == -1 ? null : this.V0APCB_DIGCTA_DEB))} ,  {FieldThreatment((this.VIND_NUMCARTAO?.ToInt() == -1 ? null : this.V0APCB_NUM_CARTAO))} ,  {FieldThreatment((this.VIND_DIADEBITO?.ToInt() == -1 ? null : this.V0APCB_DIA_DEBITO))} ,  {FieldThreatment((this.VIND_NRCERTIF?.ToInt() == -1 ? null : this.V0APCB_NRCERTIF))} , CURRENT TIMESTAMP ,  {FieldThreatment((this.VIND_MARGEM?.ToInt() == -1 ? null : this.V0APCB_MARGEM))})";

            return query;
        }
        public string V0APCB_COD_EMPRESA { get; set; }
        public string V0APCB_FONTE { get; set; }
        public string V0APCB_NUM_APOL { get; set; }
        public string V0APCB_NRENDOS { get; set; }
        public string V0APCB_CODPRODU { get; set; }
        public string V0APCB_NUM_MATR { get; set; }
        public string V0APCB_TIPOCOB { get; set; }
        public string V0APCB_AGECOBR { get; set; }
        public string V0APCB_AGENCIA { get; set; }
        public string V0APCB_OPE_CONTA { get; set; }
        public string V0APCB_NUM_CONTA { get; set; }
        public string V0APCB_DIG_CONTA { get; set; }
        public string V0APCB_AGENCIA_DEB { get; set; }
        public string VIND_AGENCIA { get; set; }
        public string V0APCB_OPERACAO_DEB { get; set; }
        public string VIND_OPERACAO { get; set; }
        public string V0APCB_NUMCTA_DEB { get; set; }
        public string VIND_NUMCONTA { get; set; }
        public string V0APCB_DIGCTA_DEB { get; set; }
        public string VIND_DIGCONTA { get; set; }
        public string V0APCB_NUM_CARTAO { get; set; }
        public string VIND_NUMCARTAO { get; set; }
        public string V0APCB_DIA_DEBITO { get; set; }
        public string VIND_DIADEBITO { get; set; }
        public string V0APCB_NRCERTIF { get; set; }
        public string VIND_NRCERTIF { get; set; }
        public string V0APCB_MARGEM { get; set; }
        public string VIND_MARGEM { get; set; }

        public static void Execute(R1000_00_PROCESSA_REGISTRO_DB_INSERT_3_Insert1 r1000_00_PROCESSA_REGISTRO_DB_INSERT_3_Insert1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_INSERT_3_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_INSERT_3_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}